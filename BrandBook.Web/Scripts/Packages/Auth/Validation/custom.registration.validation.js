// EMail Validation
    $('#Email').keyup(function () {
        checkEmailPattern(this);
    }).focus(function () {
        checkEmailPattern(this);
    }).blur(function () {
        checkEmailPattern(this);
    });

    function checkEmailPattern(obj) {
        var successIcon = $('#check-email-icon-success');
        var errorIcon = $('#check-email-icon-error');

        if ($(obj).val().match(/\b[\w\.-]+@@[\w\.-]+\.\w{2,4}\b/gi)) {
            successIcon.show();
            errorIcon.hide();
        } else {
            successIcon.hide();
            errorIcon.show();
        }
    }
// ./EMail Validation

// Username Validation
    $('#Username').keyup(function () {
        checkUsernamePattern(this);
    }).focus(function () {
        checkUsernamePattern(this);
    }).blur(function () {
        checkUsernamePattern(this);
    });

    function checkUsernamePattern(obj) {
        var successIcon = $('#check-username-icon-success');
        var errorIcon = $('#check-username-icon-error');

        if ($(obj).val().match(/[^\s]+/)) {
            successIcon.show();
            errorIcon.hide();
        } else {
            successIcon.hide();
            errorIcon.show();
        }
    }
// ./Username Validation

// Password Validation
    $('#Password').keyup(function () {
        checkPassword(this);
    }).focus(function () {
        checkPassword(this);
    }).blur(function () {
        checkPassword(this);
    });


    function checkPassword(obj) {
        var valPassword = $('#validation-password');

        if (checkPasswordComplexity($(obj).val())) {
            valPassword.hide();
        } else {
            valPassword.show();
        }
    }
// ./Password Validation

// Confirm Password Validation
    $('#ConfirmPassword').keyup(function () {
        checkConfirmPassword(this);
    }).focus(function () {
        checkConfirmPassword(this);
    }).blur(function () {
        checkConfirmPassword(this);
    });

    function checkConfirmPassword(obj) {
        var successIcon = $('#check-confirmpassword-icon-success');
        var errorIcon = $('#check-confirmpassword-icon-error');

        var passwordInputField = $('#Password');

        if ($(obj).val() === passwordInputField.val() && checkPasswordComplexity($(obj).val())) {
            successIcon.show();
            errorIcon.hide();
        } else {
            successIcon.hide();
            errorIcon.show();
        }
    }
// ./Confirm Password Validation


// Helper
    function checkPasswordComplexity(password) {
        if (password.match(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@@$!%*?&])[A-Za-z\d@@$!%*?&]{8,}$/)) {
            return true;
        } else {
            return false;
        }
    }

    function togglePasswordInfoBox() {
        $('#password-info-box').toggle('fast');
    }
// ./Helper