﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tso.world.model
{
    public struct WallTile
    {
        public WallSegments Segments;

        //the patterns of each side of the tile's wall.
        public ushort TopLeftPattern;
        public ushort TopRightPattern;
        public ushort BottomLeftPattern;
        public ushort BottomRightPattern;

        //the style of the wall at the top left and top right. bottom left and bottom right are to be obtained from the tiles in those directions.
        //1 generally means "normal wall". Not sure how to deal with cutouts while keeping these as "normal wall".
        public ushort TopLeftStyle;
        public ushort TopRightStyle;

        //Placement never seems to be not zero, so it's not included for now.
        //don't include below information when serializing as it will be generated by the client upon load

        public ushort ObjSetTLStyle; //custom styles set by objects (windows and doors)
        public ushort ObjSetTRStyle;

        public bool TopLeftDoor;
        public bool TopRightDoor;
    }
}
