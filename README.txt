# PlayGround

Unity Tips for myself.


Unity Input System
#############################################################################

Husk at Controller typen er genkendt af PC'en 

Husk at tilføje Disable og Enable på Controller mapping du aktivere. 

Du skal sætte en faktor for hvilke taster på hvis du gerne vil have tal værdien for det input.(8 tal tasten skal have en faktor 8 under Processors) 

#############################################################################


Unity code in general 
#############################################################################

[SeriealizedField] er til at du vil vise den I inspectoren men ikke vil gøre den public til andre klasser. 

[TextArea(10, 14)][SerializeField] string storyText; 
textarea makes a text area in the inspector in Unity. 
textarea, det første tal bestemmer minimuns størrelsen i vores inspector, hvor vi kan skrive i. 
textarea, det andet tal bestemmer max størrelsen og bagefter laver en scrollbar. 

[CreateAssetMenu(menuName = "State")] 
Makes itself into a field and is assignable to itself when we created. 

#############################################################################
