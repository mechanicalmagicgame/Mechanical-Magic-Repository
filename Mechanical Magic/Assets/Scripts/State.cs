public enum State {
    Talking, Default, BananaPeeling, Pause, Menu
}

public static class StateManager {
    public static State ActiveState = State.Default;
    //public static State ActiveState;

    public static void SetState(State s) {
        ActiveState = s;
    }

    public static State GetState(){
        return ActiveState;
    }
}