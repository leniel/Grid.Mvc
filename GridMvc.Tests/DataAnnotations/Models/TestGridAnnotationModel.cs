using System.ComponentModel.DataAnnotations;
using GridMvc.DataAnnotations;

namespace GridMvc.Tests.DataAnnotations.Models
{

    [MetadataType(typeof(TestGridAnnotationMetadata))]
    internal class TestGridAnnotationModel
    {
        [GridColumn]
        public string Name { get; set; }


        public int Count { get; set; }

        [NotMappedColumn]
        public string NotMapped { get; set; }

        public string Title { get; set; }
    }

    [GridTable(PagingEnabled = true, PageSize = 20)]
    internal class TestGridAnnotationMetadata
    {
        [Display(Name = "Some title")]
        public string Title { get; set; }
    }
}
