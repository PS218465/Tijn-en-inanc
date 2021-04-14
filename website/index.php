<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="images/logo20x20.png" />
    <link rel="stylesheet" href="css/MainStylesheet.css">
    <link rel="stylesheet" href="css/navbar.css">
    <link rel="stylesheet" href="css/xtra.css">
    <script src="redirect.js"></script>
    <title>Home</title>
</head>

<body style="height: max-content;">
    <div class="container">
        <div class="logo">
            <img id="logo" src="images/logo.png">
            <div class="zoekbalk">
                <img id="zoek" src="images/zoek.png">
                <input type="text">
            </div>
        </div>
        <nav>
            <ul>
                <li><a href="home.html">Home</a></li>
                <li><a href="fietss.html">Fietspagina</a></li>
                <li><a href="fietverhuur.html">Fietsverhuur</a></li>
                <li><a href="contact.html">Contact</a></li>
                <li><a href="opening.html">Openingtijden</a></li>
                <li><a href="overons.html">Over ons</a></li>
            </ul>
        </nav>
        <div class="idx"> <form>
                <?php
                echo"
                    <h3>naam</h3>
                    <textarea class='txtinput' id='naam' type='text' required></textarea> <h3>e-mail</h3>
                    <textarea class='txtinput' id='mail' pattern='[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$' type='text' required></textarea>
                    <h3>adres</h3>
                    <textarea class='txtinput' id='adres' type='text' required></textarea>
                    <h3>stad</h3>
                    <textarea class='txtinput' id='stad' type='text' required></textarea>
                    <h3>postcode</h3>
                    <textarea class='txtinput' id='postcode' pattern='[1-9][0-9]{3}\s?[a-zA-Z]{2}' type='text' required></textarea>
                    <input type='submit' id='download-btn' value='Gegevens verzenden'>";
                ?>

            </form>
        </div>

        <script src="./FileSaver.min.js"></script><!--save as library-->
        <script>
            //maak tekst bestand aan
            document.getElementById("download-btn").addEventListener("click", function () {
                var txt = "Naam = " + document.getElementById("naam").value +  "\nE-mail = "+ document.getElementById("mail").value +  "\nAdres = " + document.getElementById("adres").value +  "\nStad = " + document.getElementById("stad").value +  "\nPostcode = " + document.getElementById("postcode").value;
                var filename = "Uw-Bestelling.txt"

                var blob = new Blob([txt], {
                    type: "text/plain;charset=utf-8"
                });
                saveAs(blob, filename);
            }, false);
        </script>
        <footer>
            <div class="socials">
                <h2 class="txtcenter"><u>Social media</u></h2>
                <p class="txtcenter"><a id="fcb" href="#facebook">Facebook</a></p>
            </div>
            <div class="contact">
                <h2 class="txtcenter"><u>Contact</u></h2>
                <h3 class="txtcenter">info@defluitendefietser.nl</h3>
            </div>
            <div class="alg">
                <h3 class="txtcenter">&#169; 2021 Fluitende fietser</h3>
                <p class="txtcenter">Algemene voorwaarde</p>
                <p class="txtcenter">KVK: 88599665 | BTW NL999888492Z09</p>
            </div>
        </footer>
    </div>
</body>

</html>