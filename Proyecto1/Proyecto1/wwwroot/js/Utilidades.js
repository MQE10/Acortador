


function StorageEvent(dotnetHelper) {

    window.addEventListener('storage', function (event) {
        if (event.storageArea === localStorage) {
            // It's local storage
            dotnetHelper.invokeMethodAsync("VerificarLogueo");
           
        }
    }, false);
}

function timerInactivo(dotnetHelper)
{
    var timer;
    document.onmousemove = resetTimer;
    document.onmousedown = resetTimer;
    document.onmouseenter = resetTimer;
    document.onkeypress = resetTimer;
   

    function resetTimer()
    {
        clearTimeout(timer);
        timer = setTimeout(logout, 1800000); //30 MIN
    }

    function logout()
    {
        dotnetHelper.invokeMethodAsync("Logout");

    }
}
function modoOscuro() {
    console.log(document);
}


