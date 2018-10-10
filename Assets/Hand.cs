using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    // TOMD: If we could extend GameObject so this was limited to cards, that would be great, because type safety right?
    public List<GameObject> cards;
    public GameObject DELETE_ME_INITIAL_CARD;

	// Use this for initialization
	void Start () {
        AddCard(DELETE_ME_INITIAL_CARD);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < cards.Count; i++) {
            if (true) { // Ensure that the card isn't being interacted with before resetting its position
                MoveCardToDesignatedPosition(cards[i], i - cards.Count / 2f);
            }
        }
	}

    // normalized position is a number from -N to N signifying where the card should be rendered when at rest
    // the total number of cards in the hand is equal to 2N + 1
    void MoveCardToDesignatedPosition(GameObject c, float normalizedPosition) {
        const float ALIGNMENT_SPEED_FACTOR = 5f;
        const float X_POSITION_FACTOR = 1f;

        Vector3 desiredPosition = new Vector3(X_POSITION_FACTOR * normalizedPosition, 0, 0);
        float alignmentSpeed = ALIGNMENT_SPEED_FACTOR * Mathf.Pow(Vector3.Distance(desiredPosition, c.transform.position), 0.75f);
        Debug.Log(Vector3.Distance(desiredPosition, c.transform.position));
        c.transform.position = Vector3.MoveTowards(c.transform.position, desiredPosition, alignmentSpeed * Time.deltaTime);
    }

    public void AddCard(GameObject card) {
        cards.Add(card);
    }

    // TODO: How do we even render?
}
