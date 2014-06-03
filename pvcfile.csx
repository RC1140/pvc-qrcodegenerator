pvc.Task("nuget-push", () => {
    pvc.Source("src/Pvc.qrCodeGenerator.csproj")
       .Pipe(new PvcNuGetPack(
            createSymbolsPackage: true
       ))
       .Pipe(new PvcNuGetPush());
});
