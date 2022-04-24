using Frontend.Models;
using Frontend.Smart;
using Frontend.Views;
using System.Collections.Generic;
using System.Linq;

namespace Frontend.ViewModels
{
    public abstract class InfoScreenViewModel : PageViewModel<InfoScreenPage>
    {
        public SmartCollection<DisplayObjectViewModel> DisplayObjects { get; set; } = new SmartCollection<DisplayObjectViewModel>();

        public InfoScreenViewModel(AppShellViewModel appShell,  string title, string iconFileName)
            : base(appShell, title, iconFileName)
        { }

        public void AddDisplayObject(DisplayObjectViewModel displayObject)
        {
            DisplayObjects.Insert(displayObject.Position, displayObject);
        }

        public void RemoveDisplayObject(DisplayObjectViewModel displayObject)
        {
            DisplayObjects.Remove(displayObject);
        }

        public void AddDisplayObjects(ICollection<DisplayObjectViewModel> displayObjects)
        {
            foreach (DisplayObjectViewModel displayObject in displayObjects)
            {
                this.AddDisplayObject(displayObject);
            }
        }

        public void RemoveDisplayObjects(ICollection<DisplayObjectViewModel> displayObjects)
        {
            foreach (DisplayObjectViewModel displayObject in displayObjects)
            {
                this.RemoveDisplayObject(displayObject);
            }
        }

        public static void CreateAndAddDisplayObjects(IEnumerable<DisplayObject> displayObjects,
            ICollection<DisplayObjectViewModel> listToAdd,
            IEnumerable<int> posList)
        {
            var posListEnum = posList.GetEnumerator();
            int pos;

            foreach (DisplayObject displayObject in displayObjects)
            {
                posListEnum.MoveNext();
                pos = posListEnum.Current;

                if (displayObject is Text text)
                {
                    var obj = new TextViewModel(text, pos);
                    listToAdd.Add(obj);
                }
                else if (displayObject is Picture picture)
                {
                    var obj = new PictureViewModel(picture, pos);
                    listToAdd.Add(obj);
                }
            }
        }

        public void CreateAndAdd(DisplayObject displayObject, int pos)
        {
            if (displayObject is Text text)
            {
                var obj = new TextViewModel(text, pos);
                DisplayObjects.Add(obj);
            }
            else if (displayObject is Picture picture)
            {
                var obj = new PictureViewModel(picture, pos);
                DisplayObjects.Add(obj);
            }
        }

        public static List<GamePasswordViewModel> CreateAndAddGamePasswords(IEnumerable<PasswordGameRequirement> gamePasswords,
            ICollection<DisplayObjectViewModel> listToAdd,
            IEnumerable<int> posList)
        {
            var retList = new List<GamePasswordViewModel>();

            var posListEnum = posList.GetEnumerator();
            int pos;

            foreach (PasswordGameRequirement password in gamePasswords)
            {
                posListEnum.MoveNext();
                pos = posListEnum.Current;

                var obj = new GamePasswordViewModel(password, pos);
                listToAdd.Add(obj);
                retList.Add(obj);
            }
            return retList;
        }
    }
}
