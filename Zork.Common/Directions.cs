namespace ZorkGame
{
    //To Do:
    //  - Fix the setup for this in order to make it look more consistent
    //      - Remove the Commands reference ("Commands.North")
    public enum Directions
    {
        QUIT,
        LOOK,
        //FIX THESE PLS
        NORTH = Commands.NORTH,
        SOUTH = Commands.SOUTH,
        EAST = Commands.EAST,
        WEST = Commands.WEST,
        UNKNOWN,
        REWARD,
        SCORE
    }
}