window.addEventListener("DOMContentLoaded", function () {
    AOS.init({
        // Optional settings can be added here
        // duration: 1000,
        // once: true,
    });
});
window.refreshAOS = function () {
    AOS.refresh();
};

window.registerKeydownHandler = function (dotnetHelper) {
    window.addEventListener('keydown', function (event) {
        // Pass the key value to the Blazor method
        dotnetHelper.invokeMethodAsync('OnKeydown', event.key);
    });
};

window.removeKeydownHandler = function () {
    // Clean up the event listener when not needed
    window.removeEventListener('keydown', function (event) { });
};
