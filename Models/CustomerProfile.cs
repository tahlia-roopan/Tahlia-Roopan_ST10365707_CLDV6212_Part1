﻿/* Name: Tahlia Roopan
 * Student Number: ST10365707
 * Module: CLDV6212
 */
using Azure;
using Azure.Data.Tables;
using System;
namespace ABCRetail_CLDV6212_Part1.Models
{
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        
        // Custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerProfile()
        {
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
