# Hangman
Klassisches Hangman Konsolenspiel mit Hinweis.

## Wörter
Wörter und Hinweise sind als <code>["Key"] = "Value"</code> in einem Dictionary gespeichert.

## Spielablauf
Beim Spielbeginn wird zufällig ein Wort aus dem Dictionary ausgewählt. Danach kann der Spieler Buchstaben raten.
### Gewinn
Wenn der Spieler das Wort errät, bevor der Hangman vollständig ist, gewinnt er.
### Verlust
Wenn der Hangman vervollständigt wird bevor das Wort erraten wird, hat der Spieler verloren.
