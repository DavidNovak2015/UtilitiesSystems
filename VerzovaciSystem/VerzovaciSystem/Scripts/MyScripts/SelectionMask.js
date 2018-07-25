window.onload=function()
{
    let companyType = document.getElementByName("CompanyType");
    let company = document.getElementByName("Company");
    let find = document.getElementById("Find");

    function validate()
    {
        let p = document.createElement("p");
        p.textContent = "Ahoj";
        document.body.appendChild(p);

        //if ( (!companyType.constructor(null)) || (!company.constructor(null) ) )
        //{
            let button = document.createElement("button");
            button.textContent = "Vyhledat";
            button.class = "btn btn-default";
            button.appendChild(find);
        //}

    }

    validate();

    companyType.onclick = validate;
    companyType.onload = validate;

    let cislo1 = document.getElementById("cislo1");
    let cislo2 = document.getElementById("cislo2");
    let tlacitko = document.getElementById("tlacitko");

    function secti() {
        alert(parseInt(cislo1.value) + parseInt(cislo2.value));
    }

    tlacitko.onclick = secti;

}