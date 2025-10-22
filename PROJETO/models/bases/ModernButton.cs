using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ModernButton : Button
{
    public Color HoverColor { get; set; } = Color.CornflowerBlue;
    public Color DefaultColor { get; set; } = Color.DodgerBlue;
    public int BorderRadius { get; set; } = 15;
    public float ShadowDepth { get; set; } = 4; // Sombra mais profunda

    public ModernButton()
    {
        FlatStyle = FlatStyle.Flat;
        ForeColor = Color.White;
        BackColor = DefaultColor;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Arial", 10, FontStyle.Bold);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        Width = 200; // Largura fixada para garantir boa visualização
        Height = 60; // Altura ajustada para maior conforto
        Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Desenhando um botão com cantos arredondados e sombra
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
        path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
        path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
        path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
        path.CloseFigure();
        Region = new Region(path);

        // Desenhando sombra
        if (Enabled)
        {
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0))) // Cor da sombra
            {
                pevent.Graphics.FillPath(shadowBrush, path);
            }
        }

        // Desenhando o botão com cor de fundo
        using (Brush brush = new SolidBrush(BackColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        // Desenhando o texto
        TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        // Transição de cor suave quando o mouse entra
        BackColor = HoverColor;
        Invalidate(); // Redesenha o controle para a nova cor
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        // Volta para a cor padrão quando o mouse sai
        BackColor = DefaultColor;
        Invalidate(); // Redesenha o controle para a cor padrão
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        // Suavizar o efeito de clique
        BackColor = Color.FromArgb(0, 139, 139, 255); // Cor de fundo após o clique
        System.Threading.Tasks.Task.Delay(150).ContinueWith(t =>
        {
            Invoke(new Action(() =>
            {
                BackColor = HoverColor; // Volta para a cor hover após um pequeno delay
                Invalidate();
            }));
        });
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // ModernButton
            // 
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResumeLayout(false);

    }
}
