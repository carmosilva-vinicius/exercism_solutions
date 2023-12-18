public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) =>
        shirtNum switch 
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new System.ArgumentOutOfRangeException(
                nameof(shirtNum), $"Shirt number {shirtNum} is not valid")
        };
    public static string AnalyzeOffField(object report) =>
        report switch
        {
            string s => s,
            int i => $"There are {i} supporters at the match.",
            Foul _ => $"The referee deemed a foul.",
            Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
            Incident _ => $"An incident happened.",
            Manager manager when manager.Club == null => manager.Name,
            Manager manager => $"{manager.Name} ({manager.Club})",
            _ => throw new System.ArgumentException(
                $"Unexpected type {report.GetType()}", nameof(report))
        };
}
