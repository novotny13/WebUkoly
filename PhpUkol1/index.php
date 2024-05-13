<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MainPage</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
    <link href='https://fonts.googleapis.com/css?family=Quicksand' rel='stylesheet'>
    <link href='style.css' rel='stylesheet'>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="script.js"></script>
</head>
<body>

<?php include 'navigation.php'; ?>

<div class="background-image">
    <div class="pruh "> 
        <div class="containert row justify-content-center align-items-center">
           
                <div class="vyprodej text-center "><p>Letni damsky vyprodej</p></div>
                    <div class="d-flex align-self-start">
                        <div class="custom-button  text-center "><a href="Pani.html">Klikni zde</a></div>  
                    </div>
                    
            
    </div>
    </div>
    </div>
</div >
<div></div>
<div class="main_container">
 
    <div class="col-md-4 main_content">
      <div class="item_main">
        <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
        <div>
        <p class="text-left">Aktualní cena:</p>
        <p class=" text-left cena_text">956 kč</p>
      </div>
      </div>
    </div>
    <div class="col-md-4 main_content">
      <div class="item_main">
        <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
        <div>
        <p class="text-left">Aktualní cena:</p>
        <p class=" text-left cena_text">956 kč</p>
      </div>
      </div>
    </div>
    <div class="col-md-4 main_content">
      <div class="item_main">
        <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
        <div>
        <p class="text-left">Aktualní cena:</p>
        <p class=" text-left cena_text">956 kč</p>
      </div>
      </div>
    </div>  
      </div>
      <div class="main_container">
 
        <div class="col-md-4 main_content">
          <div class="item_main">
            <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
            <div>
            <p class="text-left">Aktualní cena:</p>
            <p class=" text-left cena_text">956 kč</p>
          </div>
          </div>
        </div>
        <div class="col-md-4 main_content">
          <div class="item_main">
            <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
            <div>
            <p class="text-left">Aktualní cena:</p>
            <p class=" text-left cena_text">956 kč</p>
          </div>
          </div>
        </div>
        <div class="col-md-4 main_content">
          <div class="item_main">
            <img src="Bryle_main.png" alt="Obrázek 1" class="img-fluid">
            <div>
            <p class="text-left">Aktualní cena:</p>
            <p class=" text-left cena_text">956 kč</p>
          </div>
          </div>
        </div> 
          </div>
          <div class="container">
    <h2>Kontaktujte nás</h2>
    <form action="email.php" method="post">
        <div class="form-group">
            <label for="name">Jméno:</label>
            <input type="text" class="form-control" id="name" name="name" required>
        </div>
        <div class="form-group">
            <label for="email">Email:</label>
            <input type="email" class="form-control" id="email" name="email" required>
        </div>
        <div class="form-group">
            <label for="message">Zpráva:</label>
            <textarea class="form-control" id="message" name="message" rows="4" required></textarea>
        </div>
        <button type="submit" class="btn btn-primary">Odeslat</button>
    </form>
</div>
<footer class="text-center">
    <p>Zaregistrujte se do našeho LuminEyE klubu a získejte 15% slevu na nákup nad 1000kč !!</p>
    <h5>Váš LuminEyE nejlepší obchod se slunečnímy brýlemi</h5>          
</footer>

</body>
</html>
