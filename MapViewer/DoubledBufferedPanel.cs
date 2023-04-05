using System.Windows.Forms;

namespace MapViewer;

public class DoubledBufferedPanel : Panel
{
    public DoubledBufferedPanel()
    {
        base.DoubleBuffered = true;
    }
}
