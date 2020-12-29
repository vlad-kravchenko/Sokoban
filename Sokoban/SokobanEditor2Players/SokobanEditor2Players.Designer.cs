namespace SokobanEditor2Players
{
    partial class SokobanEditor2Players
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SokobanEditor2Players));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolWall = new System.Windows.Forms.ToolStripButton();
            this.toolAbox = new System.Windows.Forms.ToolStripButton();
            this.boxCount = new System.Windows.Forms.ToolStripLabel();
            this.toolHere = new System.Windows.Forms.ToolStripButton();
            this.placeCount = new System.Windows.Forms.ToolStripLabel();
            this.toolDone = new System.Windows.Forms.ToolStripButton();
            this.toolNone = new System.Windows.Forms.ToolStripButton();
            this.toolUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolResize = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolResizeAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolResizeRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolResizeAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolResizeRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tooSave = new System.Windows.Forms.ToolStripButton();
            this.toolPrev = new System.Windows.Forms.ToolStripButton();
            this.toolNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolLabirintSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolSetSize = new System.Windows.Forms.ToolStripButton();
            this.panel = new System.Windows.Forms.Panel();
            this.toolUser2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolWall,
            this.toolAbox,
            this.boxCount,
            this.toolHere,
            this.placeCount,
            this.toolDone,
            this.toolNone,
            this.toolUser,
            this.toolUser2,
            this.toolStripSeparator1,
            this.toolResize,
            this.tooSave,
            this.toolPrev,
            this.toolNext,
            this.toolStripLabel1,
            this.toolLabirintSize,
            this.toolSetSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolWall
            // 
            this.toolWall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWall.Image = global::SokobanEditor2Players.Properties.Resources.wall;
            this.toolWall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWall.Name = "toolWall";
            this.toolWall.Size = new System.Drawing.Size(52, 52);
            this.toolWall.Text = "Добавить стену";
            this.toolWall.Click += new System.EventHandler(this.toolWall_Click);
            // 
            // toolAbox
            // 
            this.toolAbox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbox.Image = global::SokobanEditor2Players.Properties.Resources.abox;
            this.toolAbox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbox.Name = "toolAbox";
            this.toolAbox.Size = new System.Drawing.Size(52, 52);
            this.toolAbox.Text = "Добавить ящик";
            this.toolAbox.Click += new System.EventHandler(this.toolAbox_Click);
            // 
            // boxCount
            // 
            this.boxCount.Name = "boxCount";
            this.boxCount.Size = new System.Drawing.Size(0, 52);
            // 
            // toolHere
            // 
            this.toolHere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolHere.Image = global::SokobanEditor2Players.Properties.Resources.here;
            this.toolHere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHere.Name = "toolHere";
            this.toolHere.Size = new System.Drawing.Size(52, 52);
            this.toolHere.Text = "Добавить место для ящика";
            this.toolHere.Click += new System.EventHandler(this.toolHere_Click);
            // 
            // placeCount
            // 
            this.placeCount.Name = "placeCount";
            this.placeCount.Size = new System.Drawing.Size(0, 52);
            // 
            // toolDone
            // 
            this.toolDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDone.Image = global::SokobanEditor2Players.Properties.Resources.done;
            this.toolDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDone.Name = "toolDone";
            this.toolDone.Size = new System.Drawing.Size(52, 52);
            this.toolDone.Text = "Добавить установленный ящик";
            this.toolDone.Click += new System.EventHandler(this.toolDone_Click);
            // 
            // toolNone
            // 
            this.toolNone.Checked = true;
            this.toolNone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNone.Image = global::SokobanEditor2Players.Properties.Resources.none;
            this.toolNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNone.Name = "toolNone";
            this.toolNone.Size = new System.Drawing.Size(52, 52);
            this.toolNone.Text = "Добавить пустое место";
            this.toolNone.Click += new System.EventHandler(this.toolNone_Click);
            // 
            // toolUser
            // 
            this.toolUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUser.Image = global::SokobanEditor2Players.Properties.Resources.user1;
            this.toolUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUser.Name = "toolUser";
            this.toolUser.Size = new System.Drawing.Size(52, 52);
            this.toolUser.Text = "Добавить игрока";
            this.toolUser.Click += new System.EventHandler(this.toolUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolResize
            // 
            this.toolResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolResize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolResizeAddRow,
            this.toolResizeRemoveRow,
            this.toolResizeAddColumn,
            this.toolResizeRemoveColumn});
            this.toolResize.Image = global::SokobanEditor2Players.Properties.Resources.resize;
            this.toolResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolResize.Name = "toolResize";
            this.toolResize.Size = new System.Drawing.Size(61, 52);
            this.toolResize.Text = "Добавить/удалить строки/столбцы";
            // 
            // toolResizeAddRow
            // 
            this.toolResizeAddRow.Name = "toolResizeAddRow";
            this.toolResizeAddRow.Size = new System.Drawing.Size(136, 22);
            this.toolResizeAddRow.Text = "+1 строка";
            this.toolResizeAddRow.Click += new System.EventHandler(this.toolResizeAddRow_Click);
            // 
            // toolResizeRemoveRow
            // 
            this.toolResizeRemoveRow.Name = "toolResizeRemoveRow";
            this.toolResizeRemoveRow.Size = new System.Drawing.Size(136, 22);
            this.toolResizeRemoveRow.Text = "-1 строка";
            this.toolResizeRemoveRow.Click += new System.EventHandler(this.toolResizeRemoveRow_Click);
            // 
            // toolResizeAddColumn
            // 
            this.toolResizeAddColumn.Name = "toolResizeAddColumn";
            this.toolResizeAddColumn.Size = new System.Drawing.Size(136, 22);
            this.toolResizeAddColumn.Text = "+1 столбец";
            this.toolResizeAddColumn.Click += new System.EventHandler(this.toolResizeAddColumn_Click);
            // 
            // toolResizeRemoveColumn
            // 
            this.toolResizeRemoveColumn.Name = "toolResizeRemoveColumn";
            this.toolResizeRemoveColumn.Size = new System.Drawing.Size(136, 22);
            this.toolResizeRemoveColumn.Text = "-1 столбец";
            this.toolResizeRemoveColumn.Click += new System.EventHandler(this.toolResizeRemoveColumn_Click);
            // 
            // tooSave
            // 
            this.tooSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tooSave.Image = global::SokobanEditor2Players.Properties.Resources.save;
            this.tooSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooSave.Name = "tooSave";
            this.tooSave.Size = new System.Drawing.Size(52, 52);
            this.tooSave.Text = "Сохранить уровень";
            this.tooSave.Click += new System.EventHandler(this.tooSave_Click);
            // 
            // toolPrev
            // 
            this.toolPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrev.Image = global::SokobanEditor2Players.Properties.Resources.prev;
            this.toolPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrev.Name = "toolPrev";
            this.toolPrev.Size = new System.Drawing.Size(52, 52);
            this.toolPrev.Text = "Предыдущий уровень";
            this.toolPrev.Click += new System.EventHandler(this.toolPrev_Click);
            // 
            // toolNext
            // 
            this.toolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNext.Image = global::SokobanEditor2Players.Properties.Resources.next;
            this.toolNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNext.Name = "toolNext";
            this.toolNext.Size = new System.Drawing.Size(52, 52);
            this.toolNext.Text = "Следующий уровень";
            this.toolNext.Click += new System.EventHandler(this.toolNext_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 52);
            this.toolStripLabel1.Text = "Размер";
            // 
            // toolLabirintSize
            // 
            this.toolLabirintSize.Name = "toolLabirintSize";
            this.toolLabirintSize.Size = new System.Drawing.Size(50, 55);
            this.toolLabirintSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolLabirintSize_KeyDown);
            // 
            // toolSetSize
            // 
            this.toolSetSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSetSize.Image = global::SokobanEditor2Players.Properties.Resources.add;
            this.toolSetSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSetSize.Name = "toolSetSize";
            this.toolSetSize.Size = new System.Drawing.Size(52, 52);
            this.toolSetSize.Text = "Установить размер лабиринта";
            this.toolSetSize.Click += new System.EventHandler(this.toolSetSize_Click);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 55);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(851, 470);
            this.panel.TabIndex = 1;
            // 
            // toolUser2
            // 
            this.toolUser2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUser2.Image = global::SokobanEditor2Players.Properties.Resources.user2;
            this.toolUser2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUser2.Name = "toolUser2";
            this.toolUser2.Size = new System.Drawing.Size(52, 52);
            this.toolUser2.Text = "Добавить игрока";
            this.toolUser2.Click += new System.EventHandler(this.toolUser2_Click);
            // 
            // SokobanEditor2Players
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 525);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SokobanEditor2Players";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор уровней игры Sokoban";
            this.Load += new System.EventHandler(this.SokobanEditor2Players_Load);
            this.Resize += new System.EventHandler(this.SokobanEditor2Players_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolWall;
        private System.Windows.Forms.ToolStripButton toolAbox;
        private System.Windows.Forms.ToolStripButton toolHere;
        private System.Windows.Forms.ToolStripButton toolDone;
        private System.Windows.Forms.ToolStripButton toolNone;
        private System.Windows.Forms.ToolStripButton toolUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripDropDownButton toolResize;
        private System.Windows.Forms.ToolStripMenuItem toolResizeAddRow;
        private System.Windows.Forms.ToolStripMenuItem toolResizeRemoveRow;
        private System.Windows.Forms.ToolStripMenuItem toolResizeAddColumn;
        private System.Windows.Forms.ToolStripMenuItem toolResizeRemoveColumn;
        private System.Windows.Forms.ToolStripButton tooSave;
        private System.Windows.Forms.ToolStripButton toolPrev;
        private System.Windows.Forms.ToolStripButton toolNext;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolLabirintSize;
        private System.Windows.Forms.ToolStripButton toolSetSize;
        private System.Windows.Forms.ToolStripLabel boxCount;
        private System.Windows.Forms.ToolStripLabel placeCount;
        private System.Windows.Forms.ToolStripButton toolUser2;
    }
}

