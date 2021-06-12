using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucServerDiagram : UserControl
    {
        private CLSTreeInformation FLinkedTree;
        private List<clsDiagramServers> FLinkedServers;
        private Point FMaxPoint;
        private ucConnectionTree FParentTree;
        public CLSTreeInformation LinkedTree
        {
            get => FLinkedTree;
            set
            {
                FLinkedTree = value;
                ucTitleBarServerDiagraph.TitleText = FLinkedTree.ConnectionTreeNode.Text;

            }
        }
        public List<clsDiagramServers> LinkedServers { get => FLinkedServers; set => FLinkedServers = value; }
        public ucConnectionTree ParentTree { get => FParentTree; set => FParentTree = value; }

        public ucServerDiagram(CLSTreeInformation linkedTree)
        {
            InitializeComponent();
            LinkedTree = linkedTree;
            FMaxPoint = new Point { X = 0, Y = 0 };
        }
        public void AddServer(CLSTreeInformation treeInformation)
        {
            foreach (ServerTreeDiagram serverTreeDiagram in treeInformation.ConnectionInformation.MonitoredServer.TreeDiagrams)
            {
                if (serverTreeDiagram.ParentTreeID == LinkedTree.ServerTree.ServerTreeID)
                {
                    ucServerIcon newIcon = new ucServerIcon();
                    Point location = new Point(serverTreeDiagram.LeftLocation, serverTreeDiagram.TopLocation);
                    if (location.X <= FMaxPoint.X)
                        location.X = FMaxPoint.X + newIcon.Width;
                    FMaxPoint.X = location.X;
                    clsDiagramServers server = new clsDiagramServers(treeInformation, location, true);

                    treeInformation.ConnectionInformation.ServerIcon.Add(newIcon);
                    newIcon.TreeInformation = treeInformation;
                    newIcon.Left = location.X;
                    newIcon.Top = location.Y;
                    server.ServerIcon = newIcon;
                    this.flowLayoutPanelServerIcons.Controls.Add(newIcon);
                    newIcon.Show();
                }
            }

        }
        public void DrawServers()
        {

        }
    }
    public class clsDiagramServers : IDisposable
    {
        private CLSTreeInformation FServerTreeItem;
        private Point FLocation;
        private bool FDisplayOnBoard = true;
        private ucServerIcon FServerIcon;
        public CLSTreeInformation ServerTreeItem { get => FServerTreeItem; set => FServerTreeItem = value; }
        public Point Location { get => FLocation; set => FLocation = value; }
        public bool DisplayOnBoard { get => FDisplayOnBoard; set => FDisplayOnBoard = value; }
        public ucServerIcon ServerIcon { get => FServerIcon; set => FServerIcon = value; }

        public clsDiagramServers(CLSTreeInformation serverTreeItem, Point location, bool displayOnBoard)
        {
            FServerTreeItem = serverTreeItem;
            FLocation = location;

        }

        public void Dispose()
        {

        }
    }
}
