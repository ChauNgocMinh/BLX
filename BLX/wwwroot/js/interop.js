window.saveAsFile = function (fileName, byteBase64) {
    const linkSource = `data:application/pdf;base64,${byteBase64}`;
    const downloadLink = document.createElement("a");
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
}

//window.saveAsFile = (fileName, fileContent, fileType) => {
//    const blob = base64ToBlob(fileContent, fileType);
//    const url = window.URL.createObjectURL(blob);

//    const a = document.createElement("a");
//    a.style.display = "none";
//    a.href = url;
//    a.download = fileName;
//    document.body.appendChild(a);
//    a.click();

//    window.URL.revokeObjectURL(url);
//};

function base64ToBlob(base64, contentType) {
    contentType = contentType || '';
    const sliceSize = 1024;
    const byteCharacters = atob(base64);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
}
