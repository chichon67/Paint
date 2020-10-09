using System.Windows.Forms;

namespace geometryLib
{
    public delegate ClickResult ClickHandler(System.Drawing.Point pt, MouseButtons but, ref Curve curElement);

    public enum ClickResult
    {
        created,
        pointHandled,
        finished,
        canceled
    }
}
