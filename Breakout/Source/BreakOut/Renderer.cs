using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using D3D = Microsoft.DirectX.Direct3D;
namespace BreakOut {
	public class Renderer {
		private System.Windows.Forms.Control targetControl;
		// no property accessor

		private Device device;
		public Device Device {
			get { return device; }
		}

		public Renderer(System.Windows.Forms.Control targetControl) {
			this.targetControl = targetControl;
			PresentParameters presentParams = new PresentParameters();

//#if RELEASE
			presentParams.Windowed = true;
//#else
//       presentParams.Windowed = false;
//       presentParams.DeviceWindow = this.targetControl;
//       presentParams.BackBufferFormat = Format.X8R8G8B8;
//       presentParams.BackBufferHeight = this.targetControl.Size.Height;
//       presentParams.BackBufferWidth = this.targetControl.Size.Width;
//       presentParams.PresentationInterval = PresentInterval.Default;
//#endif

			presentParams.SwapEffect = SwapEffect.Discard;
			// store our default adapter
			int adapterOrdinal = Manager.Adapters.Default.Adapter;

			// get our device capabilities so we can check 
			Caps caps = Manager.GetDeviceCaps(adapterOrdinal, DeviceType.Hardware);
			CreateFlags createFlags;

			if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
				createFlags = CreateFlags.HardwareVertexProcessing;
			else
				createFlags = CreateFlags.SoftwareVertexProcessing;

			if (caps.DeviceCaps.SupportsPureDevice) createFlags |= CreateFlags.PureDevice;
			device = new Device(adapterOrdinal, DeviceType.Hardware, targetControl, createFlags, presentParams);
			device.DeviceReset += new EventHandler(this.OnDeviceReset);
			OnDeviceReset(device, null);
		}

		public void OnDeviceReset(object sender, EventArgs e) {
			Device newDevice = (Device)sender;
			newDevice.RenderState.Lighting = false;
			device.VertexFormat = CustomVertex.TransformedColored.Format;
			vertexBuffer = new VertexBuffer(typeof(CustomVertex.TransformedColored), 100000, device, 0, CustomVertex.TransformedColored.Format, Pool.Default);
			device.SetStreamSource(0, vertexBuffer, 0);
			InitializeFont();
			float Width, Height;
			Width = targetControl.ClientSize.Width;
			Height = targetControl.ClientSize.Height;
			if (Width > Height) Factor = Height * (1F / 0.625F);
			else Factor = Width * 0.625F;
		}
		public float Factor;
		int black = System.Drawing.Color.Black.ToArgb();
		public void BeginScene() {
			device.Clear(ClearFlags.Target, black, 1.0f, 0);
			device.BeginScene();

		}
		VertexBuffer vertexBuffer = null;
		void DrawPoly() {
			GraphicsStream stm = vertexBuffer.Lock(0, 0, 0);
			stm.Write(polys.ToArray());
			vertexBuffer.Unlock();
			int ix = 0;
			for (int i = 0; i < primitives.Count; i++) {
				device.DrawPrimitives(PrimitiveType.TriangleFan, ix, primitives[i]);
				ix += primitives[i] + 2;
			}
		}

		List<CustomVertex.TransformedColored> polys = new List<CustomVertex.TransformedColored>();
		List<int> primitives = new List<int>();
		public void AddPoly(CustomVertex.TransformedColored[] verts) {
			int nv = verts.Length;
			polys.AddRange(verts);
			primitives.Add(nv - 2);
		}
		private D3D.Font text;
		private void InitializeFont() {
			System.Drawing.Font systemfont = new System.Drawing.Font("Tahoma", 12f, FontStyle.Regular);
			text = new D3D.Font(device, systemfont);
		}
		struct txt {
			public string text; public int x; public int y; public int color;
			public txt(string text, int x, int y, int color) {
				this.text = text;
				this.x = x;
				this.y = y;
				this.color = color;
			}
		}
		List<txt> strings = new List<txt>();
		public void AddText(string text, int x,int y,int color) {
			strings.Add(new txt(text, x, y, color));
		}
		public void EndScene() {
			DrawPoly();
			for (int i = 0; i < strings.Count; i++) {
				text.DrawText(null, strings[i].text, new Point(strings[i].x, strings[i].y), strings[i].color);
			}
			device.EndScene();
			device.Present();
			strings.Clear();
			polys.Clear();
			primitives.Clear();
		}

	}
}