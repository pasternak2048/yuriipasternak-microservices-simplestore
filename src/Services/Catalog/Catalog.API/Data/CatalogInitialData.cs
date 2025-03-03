namespace Catalog.API.Data
{
	public class CatalogInitialData : IInitialData
	{
		public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
		{
			using var session = store.LightweightSession();

			if (await session.Query<Product>().AnyAsync())
			{
				return;
			}

			session.Store<Product>(GetPreconfiguredProducts());

			await session.SaveChangesAsync(cancellationToken);
		}

		private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
		{
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Gaming PC - RTX 4080",
				Category = new List<string> { "PC", "Gaming", "Graphics" },
				Description = "High-performance gaming PC with RTX 4080 graphics card and 32GB RAM.",
				ImageFile = "gaming_pc_rtx4080.jpg",
				Price = 2499.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Wireless Gaming Mouse",
				Category = new List<string> { "Accessories", "Gaming", "Mouse" },
				Description = "Ergonomic wireless mouse with customizable RGB lighting.",
				ImageFile = "wireless_gaming_mouse.jpg",
				Price = 79.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Mechanical Keyboard - RGB",
				Category = new List<string> { "Accessories", "Gaming", "Keyboard" },
				Description = "RGB mechanical keyboard with customizable keys and quiet switches.",
				ImageFile = "mechanical_keyboard_rgb.jpg",
				Price = 129.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "4K Monitor - 27 inch",
				Category = new List<string> { "PC", "Monitors", "Display" },
				Description = "27-inch 4K monitor with ultra-high definition resolution and vibrant colors.",
				ImageFile = "4k_monitor_27_inch.jpg",
				Price = 399.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "External SSD - 1TB",
				Category = new List<string> { "PC", "Storage", "External Drive" },
				Description = "Fast external SSD with 1TB of storage space for gaming and media files.",
				ImageFile = "external_ssd_1tb.jpg",
				Price = 149.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Desktop PC Case - ATX",
				Category = new List<string> { "PC", "PC Case", "Accessories" },
				Description = "ATX tower case with great airflow and cable management.",
				ImageFile = "desktop_pc_case_atx.jpg",
				Price = 89.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Power Supply - 750W",
				Category = new List<string> { "PC", "Power Supply", "Accessories" },
				Description = "750W power supply with 80+ Gold certification for optimal energy efficiency.",
				ImageFile = "power_supply_750w.jpg",
				Price = 119.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Gaming Headset - Surround Sound",
				Category = new List<string> { "Accessories", "Gaming", "Headset" },
				Description = "Premium gaming headset with 7.1 surround sound and noise-canceling microphone.",
				ImageFile = "gaming_headset_surround.jpg",
				Price = 99.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Webcam - 1080p",
				Category = new List<string> { "PC", "Webcam", "Accessories" },
				Description = "1080p webcam with built-in microphone for clear video calls and streaming.",
				ImageFile = "webcam_1080p.jpg",
				Price = 59.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Bluetooth Speakers",
				Category = new List<string> { "PC", "Audio", "Speakers" },
				Description = "Portable Bluetooth speakers with clear sound and long battery life.",
				ImageFile = "bluetooth_speakers.jpg",
				Price = 49.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Laptop Cooling Pad",
				Category = new List<string> { "PC", "Cooling", "Laptop Accessories" },
				Description = "Cooling pad with two fans for keeping your laptop cool during intense usage.",
				ImageFile = "laptop_cooling_pad.jpg",
				Price = 29.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Wireless Charger",
				Category = new List<string> { "PC", "Accessories", "Charging" },
				Description = "Qi wireless charger for fast charging of smartphones and devices.",
				ImageFile = "wireless_charger.jpg",
				Price = 19.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Mechanical Gaming Keyboard - TKL",
				Category = new List<string> { "Accessories", "Gaming", "Keyboard" },
				Description = "Tenkeyless mechanical keyboard with responsive switches and RGB lighting.",
				ImageFile = "mechanical_keyboard_tkl.jpg",
				Price = 99.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Smart Home Hub",
				Category = new List<string> { "PC", "Smart Home", "Electronics" },
				Description = "Smart home hub for controlling lights, security, and other smart devices.",
				ImageFile = "smart_home_hub.jpg",
				Price = 129.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Gaming Chair - Ergonomic",
				Category = new List<string> { "Furniture", "Gaming", "Chair" },
				Description = "Ergonomic gaming chair with lumbar support and adjustable armrests.",
				ImageFile = "gaming_chair_ergonomic.jpg",
				Price = 189.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Wireless Keyboard & Mouse Combo",
				Category = new List<string> { "Accessories", "Keyboard", "Mouse" },
				Description = "Wireless keyboard and mouse combo with ergonomic design and long battery life.",
				ImageFile = "wireless_keyboard_mouse_combo.jpg",
				Price = 39.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "USB Hub - 7 Ports",
				Category = new List<string> { "PC", "Accessories", "USB" },
				Description = "7-port USB hub for connecting multiple devices to your PC or laptop.",
				ImageFile = "usb_hub_7_ports.jpg",
				Price = 25.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Laptop Stand - Adjustable",
				Category = new List<string> { "PC", "Laptop", "Accessories" },
				Description = "Adjustable laptop stand for improved ergonomics and comfort during use.",
				ImageFile = "laptop_stand_adjustable.jpg",
				Price = 19.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "PC Cooling Fan - 120mm",
				Category = new List<string> { "PC", "Cooling", "Fan" },
				Description = "120mm PC cooling fan for better airflow and temperature control.",
				ImageFile = "pc_cooling_fan_120mm.jpg",
				Price = 14.99m
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Graphics Card - AMD RX 6700 XT",
				Category = new List<string> { "PC", "Graphics", "Gaming" },
				Description = "High-performance AMD RX 6700 XT graphics card for 4K gaming and video editing.",
				ImageFile = "graphics_card_amd_rx_6700_xt.jpg",
				Price = 649.99m
			}
		};
	}
}
