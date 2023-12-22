defmodule HighSchoolSweetheart do
  def first_letter(name) do
    name
    |> String.trim()
    |> String.first()
  end

  def initial(name) do
    name
    |> first_letter()
    |> String.upcase()
    |> then(&("#{&1}."))
  end

  def initials(full_name) do
    Enum.map(String.split(full_name, " "), &initial/1)
    |> Enum.join(" ")
  end

  def pair(full_name1, full_name2) do
    #      ******       ******
    #    **      **   **      **
    #  **         ** **         **
    # **            *            **
    # **                         **
    # **     X. X.  +  X. X.     **
    #  **                       **
    #    **                   **
    #      **               **
    #        **           **
    #          **       **
    #            **   **
    #              ***
    #               *

    # Please implement the pair/2 function

    both_initials = "#{initials(full_name1)}  +  #{initials(full_name2)}"
    heart = """
                    ******       ******
                  **      **   **      **
                **         ** **         **
               **            *            **
               **                         **
               **     #{both_initials}     **
                **                       **
                  **                   **
                    **               **
                      **           **
                        **       **
                          **   **
                            ***
                             *
               """
    heart
    |> String.replace("#", "")
  end
end
