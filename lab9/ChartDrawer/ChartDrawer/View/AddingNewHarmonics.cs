using ChartDrawer.Controller;
using ChartDrawer.Model;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View
{
    public partial class AddingNewHarmonics : Form
    {
        private IAddingNewHarmonicController _addingNewHarmonicController;

        public AddingNewHarmonics( IAddingNewHarmonicController addingNewHarmonicController )
        {
            InitializeComponent();
            _addingNewHarmonicController = addingNewHarmonicController;
        }

        private void AddingNewHarmonics_Load( object sender, EventArgs e )
        {
        }

        private void addingNewHarmonicBox_Enter( object sender, EventArgs e )
        {

        }

        private void CreateHarmonic_Click( object sender, EventArgs e )
        {
            _addingNewHarmonicController.AddNewHarmonic( new HarmonicPropertiesDto
            {
                Amplitude = Convert.ToDouble( amplitudeTextBox.Text ),
                Frequency = Convert.ToDouble( frequencyTextBox.Text ),
                Phase = Convert.ToDouble( phaseTextBox.Text ),
                HarmonicKind = sinRadioButton.Checked ? HarmonicKind.Sin : HarmonicKind.Cos
            } );
            Close();
        }

        private void CancelButton_Click( object sender, EventArgs e )
        {
            Close();
        }
    }
}
