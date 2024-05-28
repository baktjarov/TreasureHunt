namespace Characters
{
    public class WarriorTowerInfo : TowerInfo
    {
        public override void SetSelected(bool isSelected)
        {
            if (selected == isSelected) { return; }

            selected = isSelected;

            if (selected == true)
            {
                foreach (TowerInfo obj in listOfAllTowers.towerObjects)
                {
                    if (obj != this) { obj.SetSelected(false); }
                }

                onSelected?.Invoke(this);
            }
        }
    }
}