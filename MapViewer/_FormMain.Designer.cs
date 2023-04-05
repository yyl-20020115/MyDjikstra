namespace MapViewer;

partial class _FormMain
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
        label1 = new System.Windows.Forms.Label();
        numericUpDownNodeCount = new System.Windows.Forms.NumericUpDown();
        label2 = new System.Windows.Forms.Label();
        numericUpDownBranching = new System.Windows.Forms.NumericUpDown();
        label3 = new System.Windows.Forms.Label();
        numericUpDownSeed = new System.Windows.Forms.NumericUpDown();
        buttonDjikstra = new System.Windows.Forms.Button();
        buttonAstar = new System.Windows.Forms.Button();
        richTextBox1 = new System.Windows.Forms.RichTextBox();
        panel1 = new System.Windows.Forms.Panel();
        cbRandomWeights = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)numericUpDownNodeCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownBranching).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(3, 4);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(50, 17);
        label1.TabIndex = 0;
        label1.Text = "Nodes:";
        // 
        // numericUpDownNodeCount
        // 
        numericUpDownNodeCount.Location = new System.Drawing.Point(53, 2);
        numericUpDownNodeCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        numericUpDownNodeCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numericUpDownNodeCount.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        numericUpDownNodeCount.Name = "numericUpDownNodeCount";
        numericUpDownNodeCount.Size = new System.Drawing.Size(53, 23);
        numericUpDownNodeCount.TabIndex = 1;
        numericUpDownNodeCount.Value = new decimal(new int[] { 1500, 0, 0, 0 });
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(133, 4);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(69, 17);
        label2.TabIndex = 2;
        label2.Text = "Branching:";
        // 
        // numericUpDownBranching
        // 
        numericUpDownBranching.Location = new System.Drawing.Point(200, 2);
        numericUpDownBranching.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        numericUpDownBranching.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        numericUpDownBranching.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
        numericUpDownBranching.Name = "numericUpDownBranching";
        numericUpDownBranching.Size = new System.Drawing.Size(60, 23);
        numericUpDownBranching.TabIndex = 3;
        numericUpDownBranching.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new System.Drawing.Point(298, 4);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(40, 17);
        label3.TabIndex = 4;
        label3.Text = "Seed:";
        // 
        // numericUpDownSeed
        // 
        numericUpDownSeed.Location = new System.Drawing.Point(342, 2);
        numericUpDownSeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        numericUpDownSeed.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numericUpDownSeed.Name = "numericUpDownSeed";
        numericUpDownSeed.Size = new System.Drawing.Size(62, 23);
        numericUpDownSeed.TabIndex = 5;
        numericUpDownSeed.Value = new decimal(new int[] { 773, 0, 0, 0 });
        // 
        // buttonDjikstra
        // 
        buttonDjikstra.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        buttonDjikstra.Location = new System.Drawing.Point(839, 4);
        buttonDjikstra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        buttonDjikstra.Name = "buttonDjikstra";
        buttonDjikstra.Size = new System.Drawing.Size(66, 24);
        buttonDjikstra.TabIndex = 6;
        buttonDjikstra.Text = "Dijkstra";
        buttonDjikstra.UseVisualStyleBackColor = true;
        buttonDjikstra.Click += ButtonDijkstra_Click;
        // 
        // buttonAstar
        // 
        buttonAstar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        buttonAstar.Location = new System.Drawing.Point(909, 4);
        buttonAstar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        buttonAstar.Name = "buttonAstar";
        buttonAstar.Size = new System.Drawing.Size(66, 24);
        buttonAstar.TabIndex = 7;
        buttonAstar.Text = "A*";
        buttonAstar.UseVisualStyleBackColor = true;
        buttonAstar.Click += ButtonAStar_Click;
        // 
        // richTextBox1
        // 
        richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
        richTextBox1.Location = new System.Drawing.Point(0, 483);
        richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new System.Drawing.Size(1082, 197);
        richTextBox1.TabIndex = 8;
        richTextBox1.Text = "";
        // 
        // panel1
        // 
        panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        panel1.Location = new System.Drawing.Point(4, 32);
        panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(1077, 485);
        panel1.TabIndex = 9;
        // 
        // cbRandomWeights
        // 
        cbRandomWeights.AutoSize = true;
        cbRandomWeights.Checked = true;
        cbRandomWeights.CheckState = System.Windows.Forms.CheckState.Checked;
        cbRandomWeights.Location = new System.Drawing.Point(434, 4);
        cbRandomWeights.Margin = new System.Windows.Forms.Padding(4);
        cbRandomWeights.Name = "cbRandomWeights";
        cbRandomWeights.Size = new System.Drawing.Size(112, 21);
        cbRandomWeights.TabIndex = 12;
        cbRandomWeights.Text = "Random Costs";
        cbRandomWeights.UseVisualStyleBackColor = true;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1082, 680);
        Controls.Add(cbRandomWeights);
        Controls.Add(richTextBox1);
        Controls.Add(buttonAstar);
        Controls.Add(buttonDjikstra);
        Controls.Add(numericUpDownSeed);
        Controls.Add(label3);
        Controls.Add(numericUpDownBranching);
        Controls.Add(label2);
        Controls.Add(numericUpDownNodeCount);
        Controls.Add(label1);
        Controls.Add(panel1);
        DoubleBuffered = true;
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Name = "FormMain";
        Text = "Random Map";
        ((System.ComponentModel.ISupportInitialize)numericUpDownNodeCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownBranching).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown numericUpDownNodeCount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numericUpDownBranching;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numericUpDownSeed;
    private System.Windows.Forms.Button buttonDjikstra;
    private System.Windows.Forms.Button buttonAstar;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbRandomWeights;
}

