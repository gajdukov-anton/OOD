namespace ChartDrawer.Model
{
    public struct ContainerActionInfo
    {
        public int? AddedHarmonicIndex { get; private set; }
        public int? RemovedHarmonicIndex { get; private set; }

        public ContainerActionInfo( int? addedHarmonicIndex, int? removedHarmonicIndex )
        {
            AddedHarmonicIndex = addedHarmonicIndex;
            RemovedHarmonicIndex = removedHarmonicIndex;
        }
    }
}
