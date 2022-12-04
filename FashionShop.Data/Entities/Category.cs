namespace FashionShop.Data.Entities

{
    public class Category
    {
        public int Id { set; get; }
        public bool IsShowOnHome { set; get; }

        public List<ProductInCategory>? ProductInCategories { get; set; }

        public List<CategoryTranslation>? CategoryTranslations { get; set; }

    }
}
