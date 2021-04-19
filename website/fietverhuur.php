<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="images/logo20x20.png" />
    <link rel="stylesheet" href="css/MainStylesheet.css">
    <link rel="stylesheet" href="css/navbar.css">
    <link rel="stylesheet" href="css/verhuur.css">
    <!--<script src="redirect.js"></script>-->
    <title>Home</title>
</head>

<body style="height: max-content;">
    <div class="container">
        <div class="logo">
            <img id="logo" src="images/logo.png">
            <h1 class="txtcenter" id="name">De Fluitende fietser</h1>
            <div class="zoekbalk">
                <img id="zoek" src="images/zoek.png">
                <input type="text">
            </div>
        </div>
        <nav>
            <ul>
                <li><a href="home.html">Home</a></li>
                <li><a href="fietss.html">Fietspagina</a></li>
                <li><a class="active" href="fietverhuur.php">Fietsverhuur</a></li>
                <li><a href="contact.html">Contact</a></li>
                <li><a href="opening.html">Openingtijden</a></li>
                <li><a href="overons.html">Over ons</a></li>
            </ul>
        </nav>

        <div class="verhuur">
            <div class="tabel">
                <form method="post" action="index.php">
                    <table>
                        <tr>
                            <th></th>
                            <th>Fiets</th>
                            <th>Kosten</th>
                            <th>Voorraad</th>
                        </tr>
                        <tr>
                            <td><input id="checkbox1" name='lang[]' type="checkbox" value="aanhangfiets"></td>
                            <td>Aanhangfiets</td>
                            <td>€ 20,00 / dag</td>
                            <td>2</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox2" name='lang[]' type="checkbox" value="Bakfiets"></td>
                            <td>Bakfiets</th>
                            <td>€ 35,00 / dag</td>
                            <td>3</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox3" name='lang[]' type="checkbox" value="Driewielfiets"></td>
                            <td>Driewielfiets</th>
                            <td>€ 30,00 / dag</td>
                            <td>2</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox4" name='lang[]' type="checkbox" value="Elektrische fiets"></td>
                            <td>Elektrische fiets</th>
                            <td>€ 30,00 / dag</td>
                            <td>4</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox5" name='lang[]' type="checkbox" value="Ligfiets"></td>
                            <td>Ligfiets</th>
                            <td>€ 45,00 / dag</td>
                            <td>2</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox6" name='lang[]' type="checkbox" value="Oma fiets"></td>
                            <td>Oma fiets</th>
                            <td>€ 12,50 / dag</td>
                            <td>7</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox7" name='lang[]' type="checkbox" value="Speed pedelec"></td>
                            <td>Speed pedelec</th>
                            <td>€ 15,00 / dag</td>
                            <td>1</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox8" name='lang[]' type="checkbox" value="Stadsfiets"></td>
                            <td>Stadsfiets</th>
                            <td>€ 12,50 / dag</td>
                            <td>15</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox9" name='lang[]' type="checkbox" value="Vouwfiets"></td>
                            <td>Vouwfiets</th>
                            <td>€ 10,00 / dag</td>
                            <td>2</td>
                        </tr>
                        <tr>
                            <td><input id="checkbox10" name='lang[]' type="checkbox" value="Zitfiets"></td>
                            <td>Zitfiets</th>
                            <td>€ 20,00 / dag</td>
                            <td>2</td>
                        </tr>
                    </table>
                
                <div class="knop">
                    <input type="submit" onclick="redirect()" name="submit" id="submit" value="Huur de fietsen">
                </div>
                </form>
            </div>
            <div class="picsL">
                <img class="vrkppic" src="images/verhuur1.jpg">
            </div>
            <div class="picsR">
                <img class="vrkppic1" src="images/verhuur2.jpg">
            </div>
        </div>
        <footer>
            <div class="socials">
                <h2 class="txtcenter" id="white">Social media</h2>
                <a href="https://www.facebook.com/fietsmagazine"><img id="fcbook" src="images/fcbook.png"></a>
                <p class="txtcenter"><a class="white id=" fcb" href="#facebook">Facebook</a></p>
            </div>
            <div class="contact">
                <h2 class="txtcenter" id="white">Contact</h2>
                <h3 class="txtcenter" id="white">info@defluitendefietser.nl</h3>
            </div>
            <div class="alg">
                <h3 class="txtcenter" id="white">&#169; 2021 Fluitende fietser</h3>
                <a
                    href="https://www.bovag.nl/BovagWebsite/media/BovagMediaFiles/Downloads/Garantie%20en%20voorwaarden/Algemene-voorwaarden-BOVAG-tweewielerbedrijven-april-2018.pdf ">
                    <p class="txtcenter" id="white"><u>Algemene voorwaarde</u></p>
                </a>
                <p class="txtcenter" id="white">KVK: 88599665 | BTW NL999888492Z09</p>
            </div>
        </footer>
    </div>
</body>

</html>