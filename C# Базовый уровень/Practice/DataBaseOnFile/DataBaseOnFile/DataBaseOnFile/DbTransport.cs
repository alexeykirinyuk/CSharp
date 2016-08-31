using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using System.IO;
using System;

namespace DataBaseOnFile
{
    public class DbTransport
    {
        private const string dbFileName = "DataBase.db";

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
                        if (_dbTransport == null)
                        {
                            _dbTransport = new DbTransport();
                        }
                    }
                }
                return _dbTransport;
            }
        }

        private DbTransport()
        {
            _data = new List<Transport>();
            _counterID = 0;
        }

        public void Save()
        {
            var dbJsonString = new JsonDbTransport(_counterID, _data).Serialize();

            using (var streamWriter = new StreamWriter(
                new FileStream(dbFileName, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                streamWriter.WriteLine(dbJsonString);
            }
        }

        public void Load()
        {
            try
            {
                var dbJsonString = string.Empty;

                using (var streamReader = new StreamReader(
                    new FileStream(dbFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None)))
                {
                    dbJsonString = streamReader.ReadToEnd();
                }

                if (null == dbJsonString || "" == dbJsonString)
                {
                    return;
                }

                var jsonDb = new JsonDbTransport(dbJsonString);

                _data = jsonDb.Data ?? new List<Transport>();
                _counterID = jsonDb.CounterId;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Load: " + e.ToString());
            }
        }

        #region Wrappers
        public Transport this[long id]
        {
            get
            {
                return _data[GetIndexFromId(id)];
            }

            set
            {
                _data[GetIndexFromId(id)] = value;
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
            transport.TransportId = _counterID++;
            _data.Add(transport);
        }

        public void Remove(Transport transport)
        {
            _data.Remove(transport);
        }

        public void RemoveAt(long id)
        {
            _data.RemoveAt(GetIndexFromId(id));
        }

        public void Clear()
        {
            _data.Clear();
            _counterID = 0;
        }
        #endregion

        private int GetIndexFromId(long id)
        {
            var transport = _data.Where(t => t.TransportId == id).FirstOrDefault();

            if (null == transport) return -1;

            return _data.IndexOf(transport);
        }

        public override string ToString()
        {
            var builder = new StringBuilder("Transport_ID\tMark\tPrice\tHorsePower\tDateOfManufacture\tType\n");

            foreach (var transport in _data)
            {
                builder.Append(transport.ToString()).Append("\n");
            }
            return builder.ToString();
        }

        class JsonDbTransport
        {
            [JsonProperty]
            public long CounterId { get; set; }

            [JsonProperty]
            public List<Transport> Data { get; set; }

            private long _counterId = 4;

            public JsonDbTransport() { }

            public JsonDbTransport(long counterId, List<Transport> data)
            {
                CounterId = counterId;
                Data = data;
            }

            public JsonDbTransport(string json)
            {
                var value = JsonConvert.DeserializeObject<JsonDbTransport>(json, GetJsonSettings());

                CounterId = value.CounterId;
                Data = value.Data;
            }

            public string Serialize()
            {
                return JsonConvert.SerializeObject(this, GetJsonSettings());
            }

            private static JsonSerializerSettings GetJsonSettings()
            {
                return new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };
            }
        }
    }
}
