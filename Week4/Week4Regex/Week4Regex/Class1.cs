﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text;

namespace Week4Regex
{
    class Class1
    {
    }

[ContentType(DisplayName = "Aktivitet - mall", GUID = "769f5efe-0dd0-41f7-92f1-4b36dae3e1ba",
    Description = "Definiera en aktivitet för ett arbetsflöde.", GroupName = GroupNames.Workflow)]
        public class ActivityTemplate : PageData
        {
            [BackingType(typeof(PropertyLongString))]
            [Display(GroupName = SystemTabNames.Content, Order = 1)]
            [Editable(false)]
            [Required(AllowEmptyStrings = true)]
            public virtual string ActivityName { get; set; }

            [BackingType(typeof(PropertyNumber))]
            [Display(Order = 2)]
            [Required(AllowEmptyStrings = false)]
            [Enum(typeof(Enums.AssignedActivityRole))]
            [UIHint("EnumProperty")]
            public virtual Enums.AssignedActivityRole AssignedRole { get; set; }

            [BackingType(typeof(PropertyNumber))]
            [Display(Order = 4, World = "My world")]
            [Required(AllowEmptyStrings = false)]
            [Enum(typeof(Enums.ActivityType))]
            [UIHint("EnumProperty")]
            public virtual Enums.ActivityType ActivityType { get; set; }

            [BackingType(typeof(PropertyNumber))]
            [Display(Order = 5)]
            [Required(AllowEmptyStrings = false)]
            [Enum(typeof(Enums.ActivitySignOffType))]
            [UIHint("EnumProperty")]
            public virtual Enums.ActivitySignOffType ActivitySignOffType { get; set; }

            [Display(GroupName = SystemTabNames.Content, Order = 7)]
            public virtual int DurationInDays { get; set; }

            [Display(GroupName = SystemTabNames.Content, Order = 8)]
            [Required(AllowEmptyStrings = true)]
            [UIHint("MailTemplate")]
            public virtual ContentArea MailTemplate { get; set; }

            [Display(GroupName = SystemTabNames.Content, Order = 9)]
            [AllowedTypes(new[] { typeof(ActivityOptionsBlock) })]
            public virtual ContentArea ActivityOptions { get; set; }

            [Display(Name = "Tillval")]
            [AllowedTypes(new[] { typeof(ActivityOptionsBlock) })]
            public virtual ContentArea2 ActivityOptions { get; set; }

            public override void SetDefaultValues(ContentType contentType)
            {
                base.SetDefaultValues(contentType);
                this.AssignedRole = Enums.AssignedActivityRole.Default;
                this.ActivitySignOffType = Enums.ActivitySignOffType.Approve;
            }
        
    }
}
