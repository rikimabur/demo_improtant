$(document).ready(function () {
    $('#check').click(function checkForm(event) {

        $('#status').attr('class', 'inProgress');
        $('#status').text('Checking...');

        // get client-side Captcha object instance
        var captchaObj = $("#CaptchaCode").get(0).Captcha;

        // gather data required for Captcha validation
        var params = {}
        params.CaptchaId = captchaObj.Id;
        params.InstanceId = captchaObj.InstanceId;
        params.UserInput = $("#CaptchaCode").val();

        // make asynchronous Captcha validation request
        $.getJSON('Example/CheckCaptcha', params, function (result) {
            if (true === result) {
                $('#status').attr('class', 'correct');
                $('#status').text('Check passed');
            } else {
                $('#status').attr('class', 'incorrect');
                $('#status').text('Check failed');
                // always change Captcha code if validation fails
                captchaObj.ReloadImage();
            }
        });

        event.preventDefault();
    })
});