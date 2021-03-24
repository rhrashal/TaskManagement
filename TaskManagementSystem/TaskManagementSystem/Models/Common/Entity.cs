using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace TaskManagementSystem.Models
{
    public abstract class Entity
    {


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [StringLength(128)]
        public string AddBy { get; set; }

        public DateTime? AddDate { get; set; }

        [StringLength(128)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [StringLength(50)]
        public string IP { get; set; }
        [StringLength(50)]
        public string MacAddress { get; set; }

        public void SetDate()
        {
            if (AddDate == null)
            {
                AddDate = DateTime.Now;
            }
            if (!String.IsNullOrEmpty(UpdateBy) && UpdateDate == null)
            {
                UpdateDate = DateTime.Now;
            }
            //var addlist = Dns.GetHostEntry(Dns.GetHostName());
            //string GetHostName = addlist.HostName.ToString();
            //string GetIPV6 = addlist.AddressList[0].ToString();
            //string GetIPV4 = addlist.AddressList[1].ToString();
            //var a = HttpContext.Connection.RemoteIpAddress;
            //https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.IP = ip.ToString();
                }
            }
            //this.IP = Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress.ToString()).GetValue(0).ToString();
            //getting mac address
            var myInterfaceAddress = NetworkInterface.GetAllNetworkInterfaces()
         .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
         .OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
         .Select(n => n.GetPhysicalAddress())
         .FirstOrDefault();
            //add separation into mac address
            this.MacAddress = myInterfaceAddress.ToString();
            MacAddress = Regex.Replace(MacAddress, ".{2}", "$0-");
            MacAddress = MacAddress.Remove(MacAddress.Length - 1);
        }


        public virtual IEnumerable<ValidationResult> Validate()
        {
            return EntityValidator.ValidateEntity(this);
        }


    }

    public class EntityValidator
    {
        public static IEnumerable<ValidationResult> ValidateEntity<T>(T entity) where T : Entity
        {
            return new EntityValidation<T>().Validate(entity);
        }
    }
    public class EntityValidation<T> where T : Entity
    {
        public IEnumerable<ValidationResult> Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
