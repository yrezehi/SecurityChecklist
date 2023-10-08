var idleTimeout = function () {
    // 15 minutes of idle time is allowed
    var idleTime = 900000;

    // function to trigger logout on hit of time out
    var timeoutInterval;
    var timeoutCallback;

    function registerListeners() {
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
        registerListeners();
    }

    return function () {
        return {
            register: register,
        };
    }();
}();