using System;

namespace DziennikAdministratora.Repository.Model
{
    public class Category
    {
        public Guid CategoryId {get; protected set;}
        public string CategoryName {get; protected set;}
        public string BodyColor {get; protected set;}
        public string FontColor {get; protected set;}

        public Category(Guid categoryId, string categoryName, string bodyColor, string fotnColor)
        {

        }

        public void SetCategoryName(string categoryName)
        {
            if(CategoryName == categoryName)
            {
                return;
            }
            CategoryName = categoryName;
        }

        public void SetBodyColor(string bodyColor)
        {
            if(BodyColor == bodyColor)
            {
                return;
            }
            BodyColor = bodyColor;
        }

        public void SetFontColor(string fontColor)
        {
            if(FontColor == fontColor)
            {
                return;
            }
            FontColor = fontColor;
        }
    }
}