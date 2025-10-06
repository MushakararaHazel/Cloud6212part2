using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCRetails.Function
{


    public sealed class StorageOptions
    {
        public string Connection { get; set; } = "";
        public TablesOptions Tables { get; set; } = new();
        public BlobsOptions Blobs { get; set; } = new();
        public QueuesOptions Queues { get; set; } = new();
        public FilesOptions Files { get; set; } = new();

        public sealed class TablesOptions
        {
            public string Customers { get; set; } = "customers";
            public string Products { get; set; } = "products";
            public string Orders { get; set; } = "orders";
        }
        public sealed class BlobsOptions
        {
            public string ProductImages { get; set; } = "product-images";
        }
        public sealed class QueuesOptions
        {
            public string Orders { get; set; } = "orders-queue";
        }
        public sealed class FilesOptions
        {
            public string Share { get; set; } = "reports";
            public string Directory { get; set; } = "exports";
        }
    }

}
