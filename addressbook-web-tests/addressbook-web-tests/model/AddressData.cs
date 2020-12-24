using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        private string allPhones;
        private string allMails;
        //private string addressDataFromPage;
        protected string firstname;
        protected string middlename = "";
        protected string lastname;
        protected string nickname = "";
        protected string title = "";
        protected string company = "";
        protected string address = "";
        protected string home = "";
        protected string mobile = "";
        protected string work = "";
        protected string fax = "";
        protected string email = "";
        protected string email2 = "";
        protected string email3 = "";
        protected string homepage = "";
        protected string bday = "";
        protected string bmonth = "";
        protected string byear = "";
        protected string aday = "";
        protected string amonth = "";
        protected string ayear = "";
        protected string groupselection = "";
        protected string address2 = "";
        protected string phone2 = "";
        protected string notes = "";

        public AddressData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public bool Equals(AddressData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public int CompareTo(AddressData other)
        {
            if (Lastname == other.Lastname)
            {                
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }



        public string Firstname { get; set; }
        

        public string Middlename { get; set; }
       

        public string Lastname { get; set; }
        
        public string Nickname { get; set; }
       
        public string Title { get; set; }
        
        public string Company { get; set; }
        
        public string Address { get; set; }
       
        public string Home { get; set; }
        
        public string Mobile { get; set; }
        
        public string Work { get; set; }
       
        public string Fax { get; set; }
        
        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }
        
        public string Homepage { get; set; }
       
        public string Bday { get; set; }
        
        public string Bmonth { get; set; }
       
        public string Byear { get; set; }
       
        public string Aday { get; set; }
       
        public string Amonth { get; set; }
       
        public string Ayear { get; set; }
        
        public string Groupselection { get; set; }
        
        public string Address2 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string Notes { get; set; }
       
        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work) + CleanUpPhone(Phone2)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            } 
        }
        private string CleanUpPhone(string phone) 
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else 
            {
                return Regex.Replace(phone,"[ -()]","") + "\r\n";
            }
        }
        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return (ReadyEmail(Email) + ReadyEmail(Email2) + ReadyEmail(Email3)).Trim();

                }
            }
            set
            {
                allMails = value;
            }
        }
        private string ReadyEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email + "\r\n";
            }
        }
        //public string AddressDataFromPage
        //{
        //    get
        //    {
        //        if (addressDataFromPage != null)
        //        {
        //            return addressDataFromPage;
        //        }
        //        else
        //        {
        //            return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
        //        }
        //    }
        //    set
        //    {
        //        addressDataFromPage = value;
        //    }
        //}
    }
}

