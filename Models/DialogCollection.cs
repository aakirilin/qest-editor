using System.Collections.Generic;

namespace editor.Models
{
    public class DialogCollection : ObjectCollection<Dialog>
    {
        public DialogCollection(QuestResourses resourses) : base(resourses)
        {
        }

        protected override List<Dialog> selector()
        {
            return resourses.Dialogs;
        }

        public override Dialog New(bool addInCollection = false)
        {
            var result = base.New(addInCollection);
            


            return result;
        }
    }
}