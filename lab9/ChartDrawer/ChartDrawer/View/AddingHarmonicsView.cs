using ChartDrawer.Controller;
using ChartDrawer.Model;
using ChartDrawer.Util;
using System;
using System.Windows.Forms;

namespace ChartDrawer.View
{
    public partial class AddingHarmonicsView : Form, IHarmonicObserver
    {
        private IAddingHarmonicController _addingHarmonicController;
        private IHarmonicPresentation _harmonicPresentation;

        public AddingHarmonicsView( IHarmonicPresentation harmonicPresentation, IAddingHarmonicController addingNewHarmonicController )
        {
            InitializeComponent();
            _addingHarmonicController = addingNewHarmonicController;
            _harmonicPresentation = harmonicPresentation;
            FillPropertiesDefaultValue( _harmonicPresentation );
            HarmonicPropertiesChanged();
        }

        private void FillPropertiesDefaultValue( IHarmonicPresentation harmonicPresentation )
        {
            amplitudeTextBox.Text = harmonicPresentation.GetAmplitude().ToString();
            frequencyTextBox.Text = harmonicPresentation.GetFrequency().ToString();
            phaseTextBox.Text = harmonicPresentation.GetPhase().ToString();
            if (harmonicPresentation.GetHarmonicKind() == HarmonicKind.Sin)
            {
                sinRadioButton.Checked = true;
            }
            else
            {
                cosRadioButton.Checked = true;
            }
        }

        private void CreateHarmonic_Click( object sender, EventArgs e )
        {
            _addingHarmonicController.AddNewHarmonic();
        }

        private void CancelButton_Click( object sender, EventArgs e )
        {
            _addingHarmonicController.Cancel();
        }

        public void HarmonicPropertiesChanged()
        {
            harmonicStringPresentation.Text = Convertor.ConvertHarmonicToStr( _harmonicPresentation );
        }

        private void AmplitudeTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue(amplitudeTextBox))
            {
                return;
            }
            var amplitudeValue = Validator.ProcessTextBoxStringValue( amplitudeTextBox.Text );
            if ( amplitudeValue != null )
            {
                amplitudeErrorProvider.Clear();
                _addingHarmonicController.SetAmplitude( amplitudeValue.Value );
            }
            else
            {
                amplitudeErrorProvider.SetError( amplitudeTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private void SinRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if (!sinRadioButton.Focused)
            {
                return;
            }
            _addingHarmonicController.SetHarmonicKind( HarmonicKind.Sin );
        }

        private void CosRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            if (!cosRadioButton.Focused)
            {
                return;
            }
            _addingHarmonicController.SetHarmonicKind( HarmonicKind.Cos );
        }

        private void FrequencyTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue( frequencyTextBox ) )
            {
                return;
            }
            var frequencyValue = Validator.ProcessTextBoxStringValue( frequencyTextBox.Text );
            if ( frequencyValue != null )
            {
                frequencyErrorProvider.Clear();
                _addingHarmonicController.SetFrequency( frequencyValue.Value );
            }
            else
            {
                frequencyErrorProvider.SetError( frequencyTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private void PhaseTextBox_TextChanged( object sender, EventArgs e )
        {
            if ( !CanProcessTextBoxStringValue(phaseTextBox) )
            {
                return;
            }
            var phaseValue = Validator.ProcessTextBoxStringValue( phaseTextBox.Text );
            if (phaseValue != null)
            {
                phaseErrorProvider.Clear();
                _addingHarmonicController.SetPhase( phaseValue.Value );
            }
            else
            {
                phaseErrorProvider.SetError( phaseTextBox, Constants.IMPOSSIBLE_TO_USE_LETTERS );
            }
        }

        private static bool CanProcessTextBoxStringValue( TextBox textBox )
        {
            return textBox.Focused && !string.IsNullOrEmpty( textBox.Text );
        }
    }
}
