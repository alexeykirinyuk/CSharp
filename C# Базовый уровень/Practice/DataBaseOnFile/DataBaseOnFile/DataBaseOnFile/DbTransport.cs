using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System;

namespace DataBaseOnFile
{
    public class DbTransport
    {
        private static DbTransport _dbTransport;
        private static object _blockObject = new object();

        private List<Transport> _data;
        private long _counterID;

        public static DbTransport Instance
        {
            get
            {
                if (_dbTransport == null)
                {
                    lock (_blockObject)
                    {
                        if(_dbTransport == null)
                        {
                            _dbTransport = new DbTransport();
                        }
                    }
                }
                return _dbTransport;
            }
        }

        public void Save()
        {
            string dbJsonString = JsonConvert.SerializeObject(new JsonDbTransport(_counterID, _data), 
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }); ;

            using (var fileStream = new FileStream("DataBase.db", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(dbJsonString);
                streamWriter.Close();
            }
        }

        public void Load()
        {
            try
            {
                string dbJsonString = "";
                using (var fileStream = new FileStream("DataBase.db", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                {
                    var streamReader = new StreamReader(fileStream);
                    dbJsonString = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                if (null == dbJsonString || "" == dbJsonString)
                {
                    return;
                }

                var jsonDb = JsonConvert.DeserializeObject<JsonDbTransport>(dbJsonString, 
                    new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto});

                _data = jsonDb.Data ?? new List<Transport>();
                _counterID = jsonDb.CounterId;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in Load: " + e.ToString());
            }
        }

        private DbTransport()
        {
            _data = new List<Transport>();
            _counterID = 0;
        }

        #region wrappers
        public Transport this[int i]
        {
            get
            {
                return _data[i];
            }

            set
            {
                _data[i] = value;
            }
        }

        public int Count
        {
            get
            {
                return _data.Count;
            }
        }

        public void Add(Transport transport)
        {
            transport.Transport_ID = _counterID++;
            _data.Add(transport);
        }

        public void Remove(Transport transport)
        {
            _data.Remove(transport);
        }

        public void RemoveAt(int transportIndex)
        {
            _data.RemoveAt(transportIndex);
        }

        public void Insert(int index, Transport transport)
        {
            _data.Insert(index, transport);
        }

        public void Clear()
        {
            _data.Clear();
            _counterID = 0;
        }
        #endregion
        
        public override string ToString()
        {
            var builder = new StringBuilder("Transport_ID\tMark\tPrice\tHorsePower\tDateOfManufacture\tType\n");
            
            foreach(var transport in _data)
            {
                builder.Append(transport.ToString()).Append("\n");
            }
            return builder.ToString();
        }

        struct JsonDbTransport
        {
            public long CounterId;
            public List<Transport> Data;

            public JsonDbTransport(long counterId, List<Transport> data)
            {
                this.CounterId = counterId;
                this.Data = data;
            }
        }
    }
}
