var count = 1,
    click = 1,
    secretNum = 0,
    totalAmt = 0,
    houseAmt = 0,
    player1BetMoney,
    player2BetMoney,
    guessRemainP1 = 5,
    guessRemainP2 = 5;
    guessedNumbers = [];
//Page load
window.onload = function () {
    $('[id^=txt]').each(function () {
        $(this).val('');
    });
    $('[class^=disableBtnSet]').each(function () {
        $('[class^=disableBtnSet]').attr('disabled', true);
    });
}
//Validations and locking the bet
function LockBet(playerId) {
    var valid = true;
    var fields = '';
    $('input[id^=txt]').each(function () {

        if ($(this).val().length == 0)
        {
            $(this).addClass("focused");
            fields = fields+'<br/>'+ $(this).attr("name");
            valid = false;   
        }
        else
        {
            $(this).attr('disabled', true);
        }
    });
    if (valid == false)
    {
        $("#tdid").addClass('divLabel');
        document.getElementById('tdid').innerHTML = "All fields are mandatory! Please enter " + (fields) + " and lock the bet.";
        
    }
    else
    {
        $("#tdid").removeClass('divLabel');
        document.getElementById('tdid').innerHTML = '';
        $('[class=disableLockBtn]').hide();
        $("#tdid").append('<div class=divLabel id=divLabelId1 >Player ' + playerId + '<br/> Guess the number!!</div>');
        $('[class=disableBtnSet' + playerId + ']').each(function () {
            $('[class=disableBtnSet' + playerId + ']').attr('disabled', false);
        });
    }
    
}
//Total bet money cash
function totalBetMoney()
{
    player1BetMoney = document.getElementById('txtP1BetMoney');
    player2BetMoney = document.getElementById('txtP2BetMoney');
    totalAmt = parseInt(player1BetMoney.value) + parseInt(player2BetMoney.value);
    return totalAmt;
}
//Checking whether the guessed number is correct
function user(n, playerId)
{
    document.getElementById('btn' + n + playerId).style.backgroundColor = 'grey';
    var classid = 1;
    if (playerId == 1) {
        classid = 2;
        secretNum = $('#txtP2SecretNum').val();
        $("#divLabelId1").remove();
        $("#tdid").append('<div class=divLabel id=divLabelId2 >Player ' + classid + '<br/> Guess the number!!</div>');
    }
    else
    {
        secretNum = $('#txtP1SecretNum').val();
        $("#divLabelId2").remove();
        $("#tdid").append('<div class=divLabel id=divLabelId1 >Player ' + classid + '<br/> Guess the number!!</div>');
     }
     $('[class=disableBtnSet' + playerId + ']').each(function () {
        $('[class=disableBtnSet' + playerId + ']').attr('disabled', true);
     });
     $('[class=disableBtnSet' + classid + ']').each(function () {
        $('[class=disableBtnSet' + classid + ']').attr('disabled', false);           
     });
     var totalAmt = totalBetMoney(n);
     if (n == parseInt(secretNum)) {
        switch (count) {
            case 1: case 2://if the guess is correct in the 2nd attempt, he will get 90% of the amount
                houseAmt = Math.round(((totalAmt * 10) / 100));
                totalAmt = Math.round(((totalAmt * 90) / 100));//calculation
                break;
            case 4: case 3://if the guess is correct in the 3rd attempt, he will get 80% of the amount
                houseAmt = Math.round(((totalAmt * 20) / 100));
                totalAmt = Math.round(((totalAmt * 80) / 100));
                break;
            case 5: case 6://if the guess is correct in the 4thd attempt, he will get 70% of the amount
                houseAmt = Math.round(((totalAmt * 30) / 100));
                totalAmt = Math.round(((totalAmt * 70) / 100));
                break;
            case 7: case 8://if the guess is correct in the 5th attempt, he will get 60% of the amount
                houseAmt = Math.round(((totalAmt * 40) / 100));
                totalAmt = Math.round(((totalAmt * 60) / 100));
                break;
             default:
                    break;
            }
         $("#divLabelId2").remove();
         $("#divLabelId1").remove();
         $("#divId").remove();
         $('[class^=disableBtnSet]').each(function () {
            $('[class^=disableBtnSet]').attr('disabled', true);
         });
         $("#divAppend").removeClass('divLabel');
         document.getElementById('divAppend').innerHTML = '';
         $("#divAppend").append('<div class=divLabel id=divResId1 >Number ' + secretNum + ' is the correct Guess!!! Player ' + playerId + ' WINS!!! And will get $' + totalAmt + '.\nHouse gets $' + houseAmt + '</div>');
        }
     else {
        count = count + click;
        click = 1;
        if (count == 11) {
            $('[id^=btn]').each(function () {
                $('[id^="btn"]').attr('disabled', true);
            });
            $('[class^=disableBtnSet]').each(function () {
                $('[class^=disableBtnSet]').attr('disabled', true);
            });
            $("#divLabelId2").remove();
            $("#divLabelId1").remove();
            $("#divAppend").removeClass('divLabel');
            document.getElementById('divAppend').innerHTML = '';
            $("#tdid").append('<div class=divLabel id=divResId1 >Both players lose, So bet money of $' + totalAmt + ' goes to the house.</div>');
        }
        else
        {
            $("#divAppend").addClass('divLabel');
            document.getElementById('divAppend').innerHTML = "Wrong Guess!!! <br/>Better luck next time.<br>Attempts remaining: " + ((playerId > 1) ? (--guessRemainP2) : (--guessRemainP1));
         }
     } 
};