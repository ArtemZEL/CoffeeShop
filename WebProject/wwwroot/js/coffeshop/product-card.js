$(function(){    
    const root = $("[data-product-card]");
    if(!root.length) {
        return;
    }

    const input = root.find("[data-qty-value]");
    const minus = root.find("[data-qty-minus]");
    const plus = root.find("[data-qty-plus]");

    if(!input.length || !minus.length || !plus.length){
        return;
    }

    const min = Number(input.attr("min")|| 1);
    const max = Number(input.attr("max")|| 99);

    function readValue(){
        const val = Number(input.val());
        return Number.isFinite(val) ? val : min;
    }

    function writeValue(next) {
        const clamped = Math.min(max, Math.max(min, next));
        input.val(clamped);
    }

    minus.on("click",function(){
        writeValue(readValue()-1);
    });

    plus.on("click", function () {
        writeValue(readValue() + 1);
    });

    input.on("change", function () {
        writeValue(readValue());
    });
})