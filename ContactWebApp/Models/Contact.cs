namespace ContactWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        public string MobilePhone { get; set; }

        [StringLength(100)]
        public string WorkPhone { get; set; }

        [StringLength(100)]
        public string HomePhone { get; set; }
        public byte[] Image { get; set; }
    }
}
