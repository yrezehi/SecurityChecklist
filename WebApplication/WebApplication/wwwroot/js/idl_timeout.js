(function () {

    // 15 minutes of idle time is allowed 900000
    var idleTime = 5000;
    // function to trigger logout on hit of time out
    var timeoutInterval;

    function setupEvents() {
        window.onload = resetIdle;
        window.onmousemove = resetIdle;
        window.onmousedown = resetIdle;
        window.ontouchstart = resetIdle;
        window.ontouchmove = resetIdle;
        window.onclick = resetIdle;
        window.onkeydown = resetIdle;
        window.addEventListener('scroll', resetIdle, true);
    }

    function resetIdle() {
        clearTimeout(timeoutInterval);
        timeoutInterval = setTimeout(timeoutCallback, idleTime);
    }

    function timeoutCallback() {
        alert("I'm out!");
    }

    setupEvents();

})();