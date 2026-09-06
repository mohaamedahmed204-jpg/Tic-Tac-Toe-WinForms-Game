using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fifth_project
{
    public partial class frmMainForm : Form
    {
        public void LoadControl(UserControl uc)
        {
            pnlPanelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlPanelContainer.Controls.Add(uc);
        }
        public frmMainForm()
        {
            InitializeComponent();
            LoadControl(new ucMainPage());
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }
    }
    public static class ControlExtensions
    {
        public static void SetRoundedControl(this Control control, int radius, int borderWidth)
        {
            bool isButton = control is Button;

            if (isButton && control is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
            }

            control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);

            Rectangle originalBounds = control.Bounds;

            if (isButton)
            {
                void ApplyHoverEffect()
                {
                    control.Bounds = new Rectangle(
                        originalBounds.X - 2,
                        originalBounds.Y - 2,
                        originalBounds.Width + 4,
                        originalBounds.Height + 4
                    );
                }

                void ResetEffect()
                {
                    control.Bounds = originalBounds;
                }

                control.MouseEnter += (sender, e) => ApplyHoverEffect();
                control.MouseLeave += (sender, e) => ResetEffect();

                control.GotFocus += (sender, e) => ApplyHoverEffect();
                control.LostFocus += (sender, e) => ResetEffect();

                control.MouseDown += (sender, e) =>
                {
                    control.Bounds = new Rectangle(
                        originalBounds.X + 2,
                        originalBounds.Y + 2,
                        originalBounds.Width - 4,
                        originalBounds.Height - 4
                    );
                };

                control.MouseUp += (sender, e) =>
                {
                    ApplyHoverEffect();
                };
            }

            control.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int diameter = Math.Min(radius, Math.Min(control.Width, control.Height));
                Rectangle rect = new Rectangle(borderWidth, borderWidth, control.Width - (borderWidth * 2), control.Height - (borderWidth * 2));

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                    path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                    path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                    path.CloseFigure();

                    control.Region = new Region(path);

                    using (SolidBrush brush = new SolidBrush(control.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    if (borderWidth > 0)
                    {
                        using (Pen pen = new Pen(control.ForeColor, borderWidth))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }

                    if (!string.IsNullOrEmpty(control.Text))
                    {
                        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        using (SolidBrush textBrush = new SolidBrush(control.ForeColor))
                        {
                            e.Graphics.DrawString(control.Text, control.Font, textBrush, new RectangleF(0, 0, control.Width, control.Height), sf);
                        }
                    }
                }
            };

            control.Resize += (sender, e) =>
            {
                if (!control.Capture && control.Width > 0 && control.Height > 0)
                {
                    if (isButton)
                    {
                        originalBounds = new Rectangle(
                            control.Bounds.X + (control.Bounds.Width > originalBounds.Width ? 2 : 0),
                            control.Bounds.Y + (control.Bounds.Height > originalBounds.Height ? 2 : 0),
                            control.Bounds.Width > originalBounds.Width ? control.Bounds.Width - 4 : control.Bounds.Width,
                            control.Bounds.Height > originalBounds.Height ? control.Bounds.Height - 4 : control.Bounds.Height
                        );
                    }
                    else
                    {
                        originalBounds = control.Bounds;
                    }
                }
                control.Invalidate();
            };
        }
    }
}
