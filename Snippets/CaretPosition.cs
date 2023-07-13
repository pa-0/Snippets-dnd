using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;

namespace Snippets
{
    internal static class CaretPosition
    {
        private static readonly CUIAutomation8 automationClient = new();
        public static Point TryGetCaretPosition()
        {
            // try and get the active element
            IUIAutomationElement element = automationClient.GetFocusedElement();

            Guid targetGUID = typeof(IUIAutomationTextPattern2).GUID;
            IntPtr patternPtr = element.GetCurrentPatternAs(UIA_PatternIds.UIA_TextPattern2Id, ref targetGUID);

            if (patternPtr == IntPtr.Zero)
            {
                Debug.WriteLine("Defaulting to 0, 0 because element " + element.CurrentName + " did not have the target pattern.");
                return Point.Empty;
            }

            IUIAutomationTextPattern2? pattern = Marshal.GetObjectForIUnknown(patternPtr) as IUIAutomationTextPattern2;

            if (pattern == null)
            {
                Debug.WriteLine("Defaulting to 0, 0 because element " + element.CurrentName + " returned a bad pointer.");
                return Point.Empty;
            }

            IUIAutomationTextRangeArray selection = pattern.GetSelection();

            if (selection.Length == 0)
            {
                // attempt to get closest point on element.
                int clickablePointResult = element.GetClickablePoint(out tagPOINT point);
                if (clickablePointResult != 0)
                {
                    Debug.WriteLine("Defaulting to 0, 0 because element " + element.CurrentName + "'s had no caret or clickable surface.");
                    return Point.Empty;
                }

                return new Point(point.x, point.y);
            }

            IUIAutomationTextRange range = selection.GetElement(0);
            range.ExpandToEnclosingUnit(TextUnit.TextUnit_Character);
            tagRECT[] rectangles = (tagRECT[])range.GetBoundingRectangles();

            if (rectangles.Length == 0)
            {
                // attempt to get closest point on element.
                int clickablePointResult = element.GetClickablePoint(out tagPOINT point);
                if (clickablePointResult != 0)
                {
                    Debug.WriteLine("Defaulting to 0, 0 because element " + element.CurrentName + "'s had no caret or clickable surface.");
                    return Point.Empty;
                }

                return new Point(point.x, point.y);
            }

            tagRECT rect = rectangles[0];
            return new Point(rect.right, rect.bottom);
        }
    }
}
