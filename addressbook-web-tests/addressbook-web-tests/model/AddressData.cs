using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData: IEquatable<AddressData>, IComparable<AddressData>
    {
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
            this.firstname = firstname;
            this.lastname = lastname;            
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
            if (Object.ReferenceEquals(other.Lastname, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other.Firstname, null))
            {
                return 1;
            }
                             
            return Lastname.CompareTo(other.Lastname);
        }
       

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
        public string Groupselection
        {
            get
            {
                return groupselection;
            }
            set
            {
                groupselection = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
    }
}

