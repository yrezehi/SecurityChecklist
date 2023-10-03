var idleTimeout = function () {

    // 15 minutes of idle time is allowed 900000
    var idleTime = 5000;
    // function to trigger logout on hit of time out
    var timeoutInterval;
    var timeoutCallback;

    function listeners() {
        window.onload = reset;
        window.onmousemove = reset;
        window.onmousedown = reset;
        window.ontouchstart = reset;
        window.ontouchmove = reset;
        window.onclick = reset;
        window.onkeydown = reset;
        window.addEventListener('scroll', reset, true);
    }

    function reset() {
        clearTimeout(timeoutInterval);
        timeoutInterval = setTimeout(timeoutCallback, idleTime);
    }

    function register(callback) {
        timeoutCallback = callback;
        listeners();
    }

    return function () {
        return {
            register: register,
        };
    }();
}();