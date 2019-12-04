using System;
using System.Runtime.InteropServices;

namespace IMAPI2.MediaItem
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    [Flags]
    public enum SHGFI : uint
    {
        Icon = 0x000000100,              // get icon
        DisplayName = 0x000000200,       // get display name
        TypeName = 0x000000400,          // get type name
        Attributes = 0x000000800,        // get attributes
        IconLocation = 0x000001000,      // get icon location
        ExeType = 0x000002000,           // return exe type
        SysIconIndex = 0x000004000,      // get system icon index
        LinkOverlay = 0x000008000,       // put a link overlay on icon
        Selected = 0x000010000,          // show icon in selected state
        AttrSpecified = 0x000020000,    // get only specified attributes
        LargeIcon = 0x000000000,         // get large icon
        SmallIcon = 0x000000001,         // get small icon
        OpenIcon = 0x000000002,          // get open icon
        ShellIconSize = 0x000000004,     // get shell size icon
        Pidl = 0x000000008,              // pszPath is a pidl
        UseFileAttributes = 0x000000010, // use passed dwFileAttribute
        AddOverlays = 0x000000020,       // apply the appropriate overlays
        OverlayIndex = 0x000000040       // Get the index of the overlay
                                         // in the upper 8 bits of the iIcon
    }

    internal class Win32
    {

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, SHGFI uFlags);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr handle);
    }
}
