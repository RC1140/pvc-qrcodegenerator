pvc-qrcodegenerator
========
Generate QR Codes that can store string data. 

Note : The data that can be stored is limited to 2k chars.

pvc.Task("generatecode", () => {
    pvc.Source("This is a test")
       .Pipe(new QrCodeGenerator())
	   .Save("QR.png");
});
