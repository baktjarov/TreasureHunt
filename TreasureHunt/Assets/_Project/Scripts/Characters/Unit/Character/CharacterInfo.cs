namespace Characters
{
    public class CharacterInfo : UnitInfo
    {
        public override void SetSelected(bool isSelected)
        {
            base.SetSelected(isSelected);

            if (selected == isSelected) { return; }

            selected = isSelected;

            if (selected == true)
            {
                foreach (CharacterInfo obj in listOfAllUnits.moveableObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }
    }
}