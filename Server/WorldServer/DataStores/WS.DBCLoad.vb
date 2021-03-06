'
' Copyright (C) 2013 - 2014 getMaNGOS <http://www.getmangos.eu>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'
Imports System
Imports System.IO
Imports mangosVB.Common.BaseWriter
Imports mangosVB.Common.DBC

Public Module WS_DBCLoad

#Region "Spells"
    Public Sub InitializeSpellRadius()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellRadius.dbc")

            Dim radiusID As Integer
            Dim radiusValue As Single
            'Dim radiusValue2 As Single

            For i As Integer = 0 To tmpDBC.Rows - 1
                radiusID = tmpDBC.Item(i, 0)
                radiusValue = tmpDBC.Item(i, 1, DBCValueType.DBC_FLOAT)
                '   radiusValue2 = tmpDBC.Item(i, 3, DBCValueType.DBC_FLOAT) ' May be needed in the future

                SpellRadius(radiusID) = radiusValue
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellRadius initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellRadius missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub InitializeSpellCastTime()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellCastTimes.dbc")

            Dim spellCastID As Integer
            Dim spellCastTimeS As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                spellCastID = tmpDBC.Item(i, 0)
                spellCastTimeS = tmpDBC.Item(i, 1)

                SpellCastTime(spellCastID) = spellCastTimeS
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellCastTimes initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellCastTimes missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub InitializeSpellRange()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellRange.dbc")

            Dim spellRangeIndex As Integer
            'Dim spellRangeMin As Single
            Dim spellRangeMax As Single

            For i As Integer = 0 To tmpDBC.Rows - 1
                spellRangeIndex = tmpDBC.Item(i, 0)
                '   spellRangeMin = tmpDBC.Item(i, 1, DBCValueType.DBC_FLOAT) ' Added back may be needed in the future
                spellRangeMax = tmpDBC.Item(i, 2, DBCValueType.DBC_FLOAT)

                SpellRange(spellRangeIndex) = spellRangeMax
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellRanges initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellRanges missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub InitializeSpellShapeShift()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellShapeshiftForm.dbc")

            Dim id As Integer
            Dim flags1 As Integer
            Dim creatureType As Integer
            Dim attackSpeed As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                id = tmpDBC.Item(i, 0)
                flags1 = tmpDBC.Item(i, 11)
                creatureType = tmpDBC.Item(i, 12)
                attackSpeed = tmpDBC.Item(i, 13)

                SpellShapeShiftForm.Add(New TSpellShapeshiftForm(id, flags1, creatureType, attackSpeed))
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellShapeshiftForms initialized.", tmpDBC.Rows - 1)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellShapeshiftForms missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub InitializeSpellFocusObject()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellFocusObject.dbc")

            Dim spellFocusIndex As Integer
            Dim spellFocusObjectName As String

            For i As Integer = 0 To tmpDBC.Rows - 1
                spellFocusIndex = tmpDBC.Item(i, 0)
                spellFocusObjectName = tmpDBC.Item(i, 1, DBCValueType.DBC_STRING)

                SpellFocusObject(spellFocusIndex) = spellFocusObjectName
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellFocusObjects initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellFocusObjects missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub InitializeSpellDuration()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SpellDuration.dbc")

            Dim spellDurationIndex As Integer
            Dim spellDurationValue As Integer
            '            Dim SpellDurationValue2 As Integer
            '            Dim SpellDurationValue3 As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                spellDurationIndex = tmpDBC.Item(i, 0)
                spellDurationValue = tmpDBC.Item(i, 1)
                '    SpellDurationValue2 = tmpDBC.Item(i, 2) ' May be needed in the future
                '    SpellDurationValue3 = tmpDBC.Item(i, 3) ' May be needed in the future

                SpellDuration(spellDurationIndex) = spellDurationValue
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellDurations initialized.", tmpDBC.Rows - 1)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellDurations missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeSpells()
        Try
            Dim spellDBC As BufferedDBC = New BufferedDBC("dbc\Spell.dbc")
            'Console.WriteLine("[" & Format(TimeOfDay, "HH:mm:ss") & "] " & SpellDBC.GetFileInformation)
            Log.WriteLine(LogType.INFORMATION, "DBC: Initializing Spells - This may take a few moments....")

            Dim id As Integer
            For i As Long = 0 To spellDBC.Rows - 1
                Try
                    id = spellDBC.Item(i, 0)
                    SPELLs(id) = New SpellInfo
                    SPELLs(id).ID = id
                    SPELLs(id).School = spellDBC.Item(i, 1)
                    SPELLs(id).Category = spellDBC.Item(i, 2)
                    ' 3 = Not Used
                    SPELLs(id).DispellType = spellDBC.Item(i, 4)
                    SPELLs(id).Mechanic = spellDBC.Item(i, 5)
                    SPELLs(id).Attributes = spellDBC.Item(i, 6)
                    SPELLs(id).AttributesEx = spellDBC.Item(i, 7)
                    SPELLs(id).AttributesEx2 = spellDBC.Item(i, 8)
                    ' AttributesEx3 = SpellDBC.Item(i, 9)
                    ' AttributesEx4 = SpellDBC.Item(i, 10)
                    SPELLs(id).RequredCasterStance = spellDBC.Item(i, 11) ' RequiredShapeShift
                    SPELLs(id).ShapeshiftExclude = spellDBC.Item(i, 12)
                    SPELLs(id).Target = spellDBC.Item(i, 13)
                    SPELLs(id).TargetCreatureType = spellDBC.Item(i, 14)
                    SPELLs(id).FocusObjectIndex = spellDBC.Item(i, 15)
                    SPELLs(id).CasterAuraState = spellDBC.Item(i, 16)
                    SPELLs(id).TargetAuraState = spellDBC.Item(i, 17)
                    SPELLs(id).SpellCastTimeIndex = spellDBC.Item(i, 18)
                    SPELLs(id).SpellCooldown = spellDBC.Item(i, 19)
                    SPELLs(id).CategoryCooldown = spellDBC.Item(i, 20)
                    SPELLs(id).interruptFlags = spellDBC.Item(i, 21)
                    SPELLs(id).auraInterruptFlags = spellDBC.Item(i, 22)
                    SPELLs(id).channelInterruptFlags = spellDBC.Item(i, 23)
                    SPELLs(id).procFlags = spellDBC.Item(i, 24)
                    SPELLs(id).procChance = spellDBC.Item(i, 25)
                    SPELLs(id).procCharges = spellDBC.Item(i, 26)
                    SPELLs(id).maxLevel = spellDBC.Item(i, 27)
                    SPELLs(id).baseLevel = spellDBC.Item(i, 28)
                    SPELLs(id).spellLevel = spellDBC.Item(i, 29)
                    SPELLs(id).DurationIndex = spellDBC.Item(i, 30)
                    SPELLs(id).powerType = spellDBC.Item(i, 31)
                    SPELLs(id).manaCost = spellDBC.Item(i, 32)
                    SPELLs(id).manaCostPerlevel = spellDBC.Item(i, 33)
                    SPELLs(id).manaPerSecond = spellDBC.Item(i, 34)
                    SPELLs(id).manaPerSecondPerLevel = spellDBC.Item(i, 35)
                    SPELLs(id).rangeIndex = spellDBC.Item(i, 36)
                    SPELLs(id).Speed = spellDBC.Item(i, 37, DBCValueType.DBC_FLOAT)
                    SPELLs(id).modalNextSpell = spellDBC.Item(i, 38) ' Not Used
                    SPELLs(id).maxStack = spellDBC.Item(i, 39)
                    SPELLs(id).Totem(0) = spellDBC.Item(i, 40)
                    SPELLs(id).Totem(1) = spellDBC.Item(i, 41)

                    '-CORRECT-
                    SPELLs(id).Reagents(0) = spellDBC.Item(i, 42)
                    SPELLs(id).Reagents(1) = spellDBC.Item(i, 43)
                    SPELLs(id).Reagents(2) = spellDBC.Item(i, 44)
                    SPELLs(id).Reagents(3) = spellDBC.Item(i, 45)
                    SPELLs(id).Reagents(4) = spellDBC.Item(i, 46)
                    SPELLs(id).Reagents(5) = spellDBC.Item(i, 47)
                    SPELLs(id).Reagents(6) = spellDBC.Item(i, 48)
                    SPELLs(id).Reagents(7) = spellDBC.Item(i, 49)

                    SPELLs(id).ReagentsCount(0) = spellDBC.Item(i, 50)
                    SPELLs(id).ReagentsCount(1) = spellDBC.Item(i, 51)
                    SPELLs(id).ReagentsCount(2) = spellDBC.Item(i, 52)
                    SPELLs(id).ReagentsCount(3) = spellDBC.Item(i, 53)
                    SPELLs(id).ReagentsCount(4) = spellDBC.Item(i, 54)
                    SPELLs(id).ReagentsCount(5) = spellDBC.Item(i, 55)
                    SPELLs(id).ReagentsCount(6) = spellDBC.Item(i, 56)
                    SPELLs(id).ReagentsCount(7) = spellDBC.Item(i, 57)
                    '-/CORRECT-

                    SPELLs(id).EquippedItemClass = spellDBC.Item(i, 58) 'Value
                    SPELLs(id).EquippedItemSubClass = spellDBC.Item(i, 59) 'Mask
                    SPELLs(id).EquippedItemInventoryType = spellDBC.Item(i, 60) 'Mask

                    For j As Integer = 0 To 2
                        If CInt(spellDBC.Item(i, 61 + j)) <> 0 Then
                            SPELLs(id).SpellEffects(j) = New SpellEffect(SPELLs(id))

                            SPELLs(id).SpellEffects(j).ID = spellDBC.Item(i, 61 + j)
                            SPELLs(id).SpellEffects(j).valueDie = spellDBC.Item(i, 64 + j)
                            SPELLs(id).SpellEffects(j).diceBase = spellDBC.Item(i, 67 + j)
                            SPELLs(id).SpellEffects(j).dicePerLevel = spellDBC.Item(i, 70 + j, DBCValueType.DBC_FLOAT)
                            SPELLs(id).SpellEffects(j).valuePerLevel = spellDBC.Item(i, 73 + j, DBCValueType.DBC_FLOAT)
                            SPELLs(id).SpellEffects(j).valueBase = spellDBC.Item(i, 76 + j)
                            SPELLs(id).SpellEffects(j).Mechanic = spellDBC.Item(i, 79 + j)
                            SPELLs(id).SpellEffects(j).implicitTargetA = spellDBC.Item(i, 82 + j)
                            SPELLs(id).SpellEffects(j).implicitTargetB = spellDBC.Item(i, 85 + j)
                            SPELLs(id).SpellEffects(j).RadiusIndex = spellDBC.Item(i, 88 + j) ' spellradius.dbc
                            SPELLs(id).SpellEffects(j).ApplyAuraIndex = spellDBC.Item(i, 91 + j)
                            SPELLs(id).SpellEffects(j).Amplitude = spellDBC.Item(i, 94 + j)
                            SPELLs(id).SpellEffects(j).MultipleValue = spellDBC.Item(i, 97 + j)
                            SPELLs(id).SpellEffects(j).ChainTarget = spellDBC.Item(i, 100 + j)
                            SPELLs(id).SpellEffects(j).ItemType = spellDBC.Item(i, 103 + j)
                            SPELLs(id).SpellEffects(j).MiscValue = spellDBC.Item(i, 106 + j)
                            SPELLs(id).SpellEffects(j).TriggerSpell = spellDBC.Item(i, 109 + j)
                            SPELLs(id).SpellEffects(j).valuePerComboPoint = spellDBC.Item(i, 112 + j)
                        Else
                            SPELLs(id).SpellEffects(j) = Nothing
                        End If
                    Next

                    SPELLs(id).SpellVisual = spellDBC.Item(i, 115)
                    '116 = Always zero? - SpellVisual2 - Not Used
                    SPELLs(id).SpellIconID = spellDBC.Item(i, 117)
                    SPELLs(id).ActiveIconID = spellDBC.Item(i, 118)
                    '119 = spellPriority
                    SPELLs(id).Name = spellDBC.Item(i, 120, DBCValueType.DBC_STRING)
                    '121 = Always zero?
                    '122 = Always zero?
                    '123 = Always zero?
                    '124 = Always zero?
                    '125 = Always zero?
                    '126 = Always zero?
                    '127 = Always zero?
                    '128 = Always zero?
                    SPELLs(id).Rank = spellDBC.Item(i, 129, DBCValueType.DBC_STRING)
                    '130 = Always zero?
                    '131 = Always zero?
                    '132 = Always zero?
                    '133 = Always zero?
                    '134 = Always zero?
                    '135 = Always zero?
                    '136 = Always zero?
                    '137 = RankFlags
                    '138 = Description - Not Used
                    '139 = Always zero?
                    '140 = Always zero?
                    '141 = Always zero?
                    '142 = Always zero?
                    '143 = Always zero?
                    '144 = Always zero?
                    '145 = Always zero?
                    '146 = DescriptionFlags - Not Used
                    '147 = ToolTip - Not USed
                    '148 = Always zero?
                    '149 = Always zero?
                    '150 = Always zero?
                    '151 = Always zero?
                    '152 = Always zero?
                    '153 = Always zero?
                    '154 = Always zero?
                    '155 = ToolTipFlags - Not Used
                    SPELLs(id).manaCostPercent = spellDBC.Item(i, 156)
                    SPELLs(id).StartRecoveryCategory = spellDBC.Item(i, 157)
                    SPELLs(id).StartRecoveryTime = spellDBC.Item(i, 158)
                    SPELLs(id).AffectedTargetLevel = spellDBC.Item(i, 159)
                    SPELLs(id).SpellFamilyName = spellDBC.Item(i, 160)
                    SPELLs(id).SpellFamilyFlags = spellDBC.Item(i, 161) ' ClassFamilyMask SpellFamilyFlags;                   // 161+162
                    SPELLs(id).MaxTargets = spellDBC.Item(i, 163)
                    SPELLs(id).DamageType = spellDBC.Item(i, 164) ' defenseType
                    'SPELLs(ID).PreventionType = SpellDBC.Item(i, 165)
                    '166 = StanceBarOrder - Not Used

                    For j As Integer = 0 To 2
                        If SPELLs(id).SpellEffects(j) IsNot Nothing Then
                            SPELLs(id).SpellEffects(j).DamageMultiplier = spellDBC.Item(i, 167 + j, DBCValueType.DBC_FLOAT)
                        End If
                    Next

                    '170 = MinFactionId - Not Used
                    '171 = MinReputation - Not Used
                    '172 = RequiredAuraVision - Not Used

                    SPELLs(id).InitCustomAttributes()

                Catch e As Exception
                    Log.WriteLine(LogType.FAILED, "Line {0} caused error: {1}", i, e.ToString)
                End Try

            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Spells initialized.", spellDBC.Rows - 1)
            spellDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : Spells missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeSpellChains()
        Try
            Dim spellChainQuery As New DataTable
            WorldDatabase.Query("SELECT spell_id, prev_spell FROM spell_chain", spellChainQuery)

            For Each spellChain As DataRow In spellChainQuery.Rows
                SpellChains.Add(CInt(spellChain.Item("spell_id")), CInt(spellChain.Item("prev_spell")))
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} SpellChains initialized.", spellChainQuery.Rows.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : SpellChains missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Taxi"
    Public Sub InitializeTaxiNodes()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\TaxiNodes.dbc")

            Dim taxiPosX As Single
            Dim taxiPosY As Single
            Dim taxiPosZ As Single
            Dim taxiMapID As Integer
            Dim taxiNode As Integer
            Dim taxiMountTypeHorde As Integer
            Dim taxiMountTypeAlliance As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                taxiNode = tmpDBC.Item(i, 0)
                taxiMapID = tmpDBC.Item(i, 1)
                taxiPosX = tmpDBC.Item(i, 2, DBCValueType.DBC_FLOAT)
                taxiPosY = tmpDBC.Item(i, 3, DBCValueType.DBC_FLOAT)
                taxiPosZ = tmpDBC.Item(i, 4, DBCValueType.DBC_FLOAT)
                taxiMountTypeHorde = tmpDBC.Item(i, 14)
                taxiMountTypeAlliance = tmpDBC.Item(i, 15)

                If Config.Maps.Contains(taxiMapID.ToString) Then
                    TaxiNodes.Add(taxiNode, New TTaxiNode(taxiPosX, taxiPosY, taxiPosZ, taxiMapID, taxiMountTypeHorde, taxiMountTypeAlliance))
                End If
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} TaxiNodes initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : TaxiNodes missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeTaxiPaths()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\TaxiPath.dbc")

            Dim taxiNode As Integer
            Dim taxiFrom As Integer
            Dim taxiTo As Integer
            Dim taxiPrice As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                taxiNode = tmpDBC.Item(i, 0)
                taxiFrom = tmpDBC.Item(i, 1)
                taxiTo = tmpDBC.Item(i, 2)
                taxiPrice = tmpDBC.Item(i, 3)

                TaxiPaths.Add(taxiNode, New TTaxiPath(taxiFrom, taxiTo, taxiPrice))

            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} TaxiPaths initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : TaxiPath missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeTaxiPathNodes()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\TaxiPathNode.dbc")

            'Dim taxiNode As Integer
            Dim taxiPath As Integer
            Dim taxiSeq As Integer
            Dim taxiMapID As Integer
            Dim taxiPosX As Single
            Dim taxiPosY As Single
            Dim taxiPosZ As Single
            Dim taxiAction As Integer
            Dim taxiWait As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                'taxiNode = tmpDBC.Item(i, 0)
                taxiPath = tmpDBC.Item(i, 1)
                taxiSeq = tmpDBC.Item(i, 2)
                taxiMapID = tmpDBC.Item(i, 3)
                taxiPosX = tmpDBC.Item(i, 4, DBCValueType.DBC_FLOAT)
                taxiPosY = tmpDBC.Item(i, 5, DBCValueType.DBC_FLOAT)
                taxiPosZ = tmpDBC.Item(i, 6, DBCValueType.DBC_FLOAT)
                taxiAction = tmpDBC.Item(i, 7)
                taxiWait = tmpDBC.Item(i, 8)

                If Config.Maps.Contains(taxiMapID.ToString) Then
                    If TaxiPathNodes.ContainsKey(taxiPath) = False Then
                        TaxiPathNodes.Add(taxiPath, New Dictionary(Of Integer, TTaxiPathNode))
                    End If
                    TaxiPathNodes(taxiPath).Add(taxiSeq, New TTaxiPathNode(taxiPosX, taxiPosY, taxiPosZ, taxiMapID, taxiPath, taxiSeq, taxiAction, taxiWait))
                End If
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} TaxiPathNodes initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : TaxiPathNode missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Skills"
    Public Sub InitializeSkillLines()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SkillLine.dbc")

            Dim skillID As Integer
            Dim skillLine As Integer
            'Dim skillUnk1 As Integer
            'Dim skillName As String
            'Dim skillDescription As String
            'Dim skillSpellIcon As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                skillID = tmpDBC.Item(i, 0)
                skillLine = tmpDBC.Item(i, 1) ' Type or Category?
                'skillUnk1 = tmpDBC.Item(i, 2) ' May be needed in the future
                'skillName = tmpDBC.Item(i, 3) ' May be needed in the future
                'skillName = tmpDBC.Item(i, 3, DBCValueType.DBC_STRING)
                'skillDescription = tmpDBC.Item(i, 12, DBCValueType.DBC_STRING)
                'skillSpellIcon = tmpDBC.Item(i, 21)

                SkillLines(skillID) = skillLine
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SkillLines initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SkillLines missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeSkillLineAbility()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\SkillLineAbility.dbc")

            For i As Integer = 0 To tmpDBC.Rows - 1
                Dim tmpSkillLineAbility As New TSkillLineAbility

                tmpSkillLineAbility.ID = tmpDBC.Item(i, 0)
                tmpSkillLineAbility.SkillID = tmpDBC.Item(i, 1)
                tmpSkillLineAbility.SpellID = tmpDBC.Item(i, 2)
                tmpSkillLineAbility.Unknown1 = tmpDBC.Item(i, 3) ' May be needed in the future
                tmpSkillLineAbility.Unknown2 = tmpDBC.Item(i, 4) ' May be needed in the future
                tmpSkillLineAbility.Unknown3 = tmpDBC.Item(i, 5) ' May be needed in the future
                tmpSkillLineAbility.Unknown4 = tmpDBC.Item(i, 6) ' May be needed in the future
                tmpSkillLineAbility.Required_Skill_Value = tmpDBC.Item(i, 7)
                tmpSkillLineAbility.Forward_SpellID = tmpDBC.Item(i, 8)
                tmpSkillLineAbility.Unknown5 = tmpDBC.Item(i, 9) ' May be needed in the future
                tmpSkillLineAbility.Max_Value = tmpDBC.Item(i, 10)
                tmpSkillLineAbility.Min_Value = tmpDBC.Item(i, 11)

                SkillLineAbility.Add(tmpSkillLineAbility.ID, tmpSkillLineAbility)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SkillLineAbilitys initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SkillLineAbility missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

#End Region

#Region "Locks"
    Public Sub InitializeLocks()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\Lock.dbc")

            Dim lockID As Integer
            Dim keyType(4) As Byte
            Dim key(4) As Integer
            Dim reqMining As Integer
            Dim reqLockSkill As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                lockID = tmpDBC.Item(i, 0)
                keyType(0) = CByte(tmpDBC.Item(i, 1))
                keyType(1) = CByte(tmpDBC.Item(i, 2))
                keyType(2) = CByte(tmpDBC.Item(i, 3))
                keyType(3) = CByte(tmpDBC.Item(i, 4))
                keyType(4) = CByte(tmpDBC.Item(i, 5))
                key(0) = tmpDBC.Item(i, 9)
                key(1) = tmpDBC.Item(i, 10)
                key(2) = tmpDBC.Item(i, 11)
                key(3) = tmpDBC.Item(i, 12)
                key(4) = tmpDBC.Item(i, 13)
                reqMining = tmpDBC.Item(i, 17) ' Not sure about this one leaving it like it is
                reqLockSkill = tmpDBC.Item(i, 17)

                Locks(lockID) = New TLock(keyType, key, reqMining, reqLockSkill)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Locks initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : Locks missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "AreaTable"
    Public Sub InitializeAreaTable()
        Try
            Dim tmpDbc As BufferedDBC = New BufferedDBC("dbc\AreaTable.dbc")

            Dim areaID As Integer
            Dim areaMapID As Integer
            Dim areaExploreFlag As Integer
            Dim areaLevel As Integer
            Dim areaZone As Integer
            Dim areaZoneType As Integer
            'Dim areaEXP As Integer
            'Dim areaTeam As Integer
            'Dim areaName As String

            For i As Integer = 0 To tmpDbc.Rows - 1
                areaID = tmpDbc.Item(i, 0)
                areaMapID = tmpDbc.Item(i, 1) ' May be needed in the future
                areaZone = tmpDbc.Item(i, 2)    'Parent Map
                areaExploreFlag = tmpDbc.Item(i, 3)
                areaZoneType = tmpDbc.Item(i, 4) ' 312 For Cities - Flags
                ' 5        m_SoundProviderPref
                ' 6        m_SoundProviderPrefUnderwater
                ' 7        m_AmbienceID
                'areaEXP = tmpDBC.Item(i, 8) ' May be needed in the future - m_ZoneMusic
                ' 9        m_IntroSound
                areaLevel = tmpDbc.Item(i, 10)
                'areaName = tmpDBC.Item(i, 11) ' May be needed in the future
                ' 19 string flags
                'areaTeam = tmpDBC.Item(i, 20)
                ' 24 = LiquidTypeOverride

                If areaLevel > 255 Then areaLevel = 255
                If areaLevel < 0 Then areaLevel = 0

                AreaTable(areaExploreFlag) = New TArea
                AreaTable(areaExploreFlag).ID = areaID
                AreaTable(areaExploreFlag).mapId = areaMapID
                AreaTable(areaExploreFlag).Level = areaLevel
                'AreaTable(areaExploreFlag).Name = areaName
                AreaTable(areaExploreFlag).Zone = areaZone
                AreaTable(areaExploreFlag).ZoneType = areaZoneType
                'AreaTable(areaExploreFlag).Team = areaTeam
            Next i
            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Areas initialized.", tmpDbc.Rows - 1)
            tmpDbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : AreaTable missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Emotes"
    Public Sub InitializeEmotes()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\Emotes.dbc")
            Dim emoteID As Integer
            Dim emoteState As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                emoteID = tmpDBC.Item(i, 0)
                emoteState = tmpDBC.Item(i, 4)

                If emoteID <> 0 Then EmotesState(emoteID) = emoteState
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Emotes initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : Emotes missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeEmotesText()
        Try
            Dim tmpDbc As BufferedDBC = New BufferedDBC("dbc\EmotesText.dbc")
            Dim textEmoteID As Integer
            Dim emoteID As Integer
            'Dim EmoteID2 As Integer
            'Dim EmoteID3 As Integer
            'Dim EmoteID4 As Integer
            'Dim EmoteID5 As Integer
            'Dim EmoteID6 As Integer

            For i As Integer = 0 To tmpDbc.Rows - 1
                textEmoteID = tmpDbc.Item(i, 0)
                emoteID = tmpDbc.Item(i, 2)
                'EmoteID2 = tmpDBC.Item(i, 3) ' May be needed in the future
                'EmoteID3 = tmpDBC.Item(i, 4) ' May be needed in the future
                'EmoteID4 = tmpDBC.Item(i, 5) ' May be needed in the future
                'EmoteID5 = tmpDBC.Item(i, 7) ' May be needed in the future
                'EmoteID6 = tmpDBC.Item(i, 8) ' May be needed in the future

                If emoteID <> 0 Then EmotesText(textEmoteID) = emoteID
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} EmotesText initialized.", tmpDbc.Rows - 1)
            tmpDbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : EmotesText missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Factions"
    Public Sub InitializeFactions()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\Faction.dbc")

            Dim factionID As Integer
            Dim factionFlag As Integer
            Dim flags(3) As Integer
            Dim reputationStats(3) As Integer
            Dim reputationFlags(3) As Integer
            'Dim factionName As String

            For i As Integer = 0 To tmpDBC.Rows - 1
                factionID = tmpDBC.Item(i, 0)
                factionFlag = tmpDBC.Item(i, 1)
                flags(0) = tmpDBC.Item(i, 2)
                flags(1) = tmpDBC.Item(i, 3)
                flags(2) = tmpDBC.Item(i, 4)
                flags(3) = tmpDBC.Item(i, 5)
                reputationStats(0) = tmpDBC.Item(i, 10)
                reputationStats(1) = tmpDBC.Item(i, 11)
                reputationStats(2) = tmpDBC.Item(i, 12)
                reputationStats(3) = tmpDBC.Item(i, 13)
                reputationFlags(0) = tmpDBC.Item(i, 14)
                reputationFlags(1) = tmpDBC.Item(i, 15)
                reputationFlags(2) = tmpDBC.Item(i, 16)
                reputationFlags(3) = tmpDBC.Item(i, 17)
                'factionName = tmpDBC.Item(i, 19) ' May be needed in the future

                FactionInfo(factionID) = New TFaction(factionID, factionFlag, _
                   flags(0), flags(1), flags(2), flags(3), _
                   reputationStats(0), reputationStats(1), reputationStats(2), reputationStats(3), _
                   reputationFlags(0), reputationFlags(1), reputationFlags(2), reputationFlags(3))
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Factions initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : Factions missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeFactionTemplates()
        Try
            'Loading from DBC
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\FactionTemplate.dbc")

            Dim templateID As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                templateID = tmpDBC.Item(i, 0)
                FactionTemplatesInfo.Add(templateID, New TFactionTemplate)
                FactionTemplatesInfo(templateID).FactionID = tmpDBC.Item(i, 1)
                FactionTemplatesInfo(templateID).ourMask = tmpDBC.Item(i, 3)
                FactionTemplatesInfo(templateID).friendMask = tmpDBC.Item(i, 4)
                FactionTemplatesInfo(templateID).enemyMask = tmpDBC.Item(i, 5)
                FactionTemplatesInfo(templateID).enemyFaction1 = tmpDBC.Item(i, 6)
                FactionTemplatesInfo(templateID).enemyFaction2 = tmpDBC.Item(i, 7)
                FactionTemplatesInfo(templateID).enemyFaction3 = tmpDBC.Item(i, 8)
                FactionTemplatesInfo(templateID).enemyFaction4 = tmpDBC.Item(i, 9)
                FactionTemplatesInfo(templateID).friendFaction1 = tmpDBC.Item(i, 10)
                FactionTemplatesInfo(templateID).friendFaction2 = tmpDBC.Item(i, 11)
                FactionTemplatesInfo(templateID).friendFaction3 = tmpDBC.Item(i, 12)
                FactionTemplatesInfo(templateID).friendFaction4 = tmpDBC.Item(i, 13)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} FactionTemplates initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : FactionsTemplates missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeCharRaces()
        Try
            'Loading from DBC
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\ChrRaces.dbc")

            Dim raceID As Integer
            Dim factionID As Integer
            Dim modelM As Integer
            Dim modelF As Integer
            Dim teamID As Integer '1 = Horde / 7 = Alliance
            Dim taxiMask As UInteger
            Dim cinematicID As Integer
            Dim name As String

            For i As Integer = 0 To tmpDBC.Rows - 1
                raceID = tmpDBC.Item(i, 0)
                factionID = tmpDBC.Item(i, 2)
                modelM = tmpDBC.Item(i, 4)
                modelF = tmpDBC.Item(i, 5)
                teamID = tmpDBC.Item(i, 8)
                taxiMask = tmpDBC.Item(i, 14)
                cinematicID = tmpDBC.Item(i, 16)
                name = tmpDBC.Item(i, 17, DBCValueType.DBC_STRING)

                CharRaces(CByte(raceID)) = New TCharRace(CShort(factionID), modelM, modelF, CByte(teamID), taxiMask, cinematicID, name)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} CharRaces initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : CharRaces missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub InitializeCharClasses()
        Try
            'Loading from DBC
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\ChrClasses.dbc")

            Dim classID As Integer
            Dim cinematicID As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                classID = tmpDBC.Item(i, 0)
                cinematicID = tmpDBC.Item(i, 5)

                CharClasses(CByte(classID)) = New TCharClass(cinematicID)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} CharClasses initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : CharRaces missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "DurabilityCosts"
    Public Sub InitializeDurabilityCosts()
        Try
            Dim tmpDBC As BufferedDBC = New BufferedDBC("dbc\DurabilityCosts.dbc")

            Dim itemBroken As Integer
            Dim itemType As Integer
            Dim itemPrice As Integer

            For i As Integer = 0 To tmpDBC.Rows - 1
                itemBroken = tmpDBC.Item(i, 0)

                For itemType = 1 To tmpDBC.Columns - 1
                    itemPrice = tmpDBC.Item(i, itemType)
                    DurabilityCosts(itemBroken, itemType - 1) = itemPrice
                Next

            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} DurabilityCosts initialized.", tmpDBC.Rows - 1)
            tmpDBC.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : DurabilityCosts missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Talents"
    Public Sub LoadTalentDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\Talent.dbc")

            Dim tmpInfo As TalentInfo

            For i As Integer = 0 To dbc.Rows - 1
                tmpInfo = New TalentInfo

                tmpInfo.TalentID = dbc.Item(i, 0)
                tmpInfo.TalentTab = dbc.Item(i, 1)
                tmpInfo.Row = dbc.Item(i, 2)
                tmpInfo.Col = dbc.Item(i, 3)
                tmpInfo.RankID(0) = dbc.Item(i, 4)
                tmpInfo.RankID(1) = dbc.Item(i, 5)
                tmpInfo.RankID(2) = dbc.Item(i, 6)
                tmpInfo.RankID(3) = dbc.Item(i, 7)
                tmpInfo.RankID(4) = dbc.Item(i, 8)

                tmpInfo.RequiredTalent(0) = dbc.Item(i, 13) ' dependson
                'tmpInfo.RequiredTalent(1) = DBC.Item(i, 14) ' ???
                'tmpInfo.RequiredTalent(2) = DBC.Item(i, 15) ' ???
                tmpInfo.RequiredPoints(0) = dbc.Item(i, 16) ' dependsonrank
                'tmpInfo.RequiredPoints(1) = DBC.Item(i, 17) ' ???
                'tmpInfo.RequiredPoints(2) = DBC.Item(i, 18) ' ???

                Talents.Add(tmpInfo.TalentID, tmpInfo)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Talents initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : Talents missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub LoadTalentTabDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\TalentTab.dbc")

            Dim talentTab As Integer
            Dim talentMask As Integer
            'Dim TalentTabPage As Integer

            For i As Integer = 0 To dbc.Rows - 1
                talentTab = dbc.Item(i, 0)
                talentMask = dbc.Item(i, 12)
                '   TalentTabPage = dbc.Item(i, 13) ' May be needed in the future

                TalentsTab.Add(talentTab, talentMask)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} Talent tabs initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : TalentTab missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "AuctionHouse"
    Public Sub LoadAuctionHouseDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\AuctionHouse.dbc")

            Dim ahId As Integer
            Dim fee As Integer
            Dim tax As Integer

            'What the hell is this doing? o_O

            For i As Integer = 0 To dbc.Rows - 1
                ahId = dbc.Item(i, 0)
                fee = dbc.Item(i, 2)
                tax = dbc.Item(i, 3)

                'TODO: This needs to be put into a class or dictionary collection
                AuctionID = ahId
                AuctionFee = fee
                AuctionTax = tax

            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} AuctionHouses initialized.", dbc.Rows - 1)
            dbc.Dispose()

        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : AuctionHouse missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

#End Region

#Region "Items"
    Public Sub LoadSpellItemEnchantments()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\SpellItemEnchantment.dbc")

            Dim id As Integer
            Dim type(2) As Integer
            Dim amount(2) As Integer
            Dim spellID(2) As Integer
            Dim auraID As Integer
            Dim slot As Integer
            'Dim EnchantmentConditions As Integer

            For i As Integer = 0 To dbc.Rows - 1
                id = dbc.Item(i, 0)
                type(0) = dbc.Item(i, 1)
                type(1) = dbc.Item(i, 2)
                'Type(2) = DBC.Item(i, 3)
                amount(0) = dbc.Item(i, 4)
                amount(1) = dbc.Item(i, 7)
                'Amount(2) = DBC.Item(i, 6)
                spellID(0) = dbc.Item(i, 10)
                spellID(1) = dbc.Item(i, 11)
                'SpellID(2) = DBC.Item(i, 12)
                auraID = dbc.Item(i, 22)
                slot = dbc.Item(i, 23)
                'EnchantmentConditions = DBC.Item(i, 23) ' TODO: Correct?

                SpellItemEnchantments.Add(id, New TSpellItemEnchantment(type, amount, spellID, auraID, slot)) ', EnchantmentConditions))
            Next

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} SpellItemEnchantments initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : SpellItemEnchantments missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub LoadItemSet()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\ItemSet.dbc")

            Dim id As Integer
            Dim name As String
            Dim itemID(7) As Integer
            Dim spellID(7) As Integer
            Dim itemCount(7) As Integer
            Dim requiredSkillID As Integer
            Dim requiredSkillValue As Integer

            For i As Integer = 0 To dbc.Rows - 1
                id = dbc.Item(i, 0)
                name = dbc.Item(i, 1, DBCValueType.DBC_STRING)
                itemID(0) = dbc.Item(i, 10) ' 10 - 26
                itemID(1) = dbc.Item(i, 11)
                itemID(2) = dbc.Item(i, 12)
                itemID(3) = dbc.Item(i, 13)
                itemID(4) = dbc.Item(i, 14)
                itemID(5) = dbc.Item(i, 15)
                itemID(6) = dbc.Item(i, 16)
                itemID(7) = dbc.Item(i, 17)
                'SpellID(0) = DBC.Item(i, 27) ' 27 - 34
                'SpellID(1) = DBC.Item(i, 28)
                'SpellID(2) = DBC.Item(i, 29)
                'SpellID(3) = DBC.Item(i, 30)
                'SpellID(4) = DBC.Item(i, 31)
                'SpellID(5) = DBC.Item(i, 32)
                'SpellID(6) = DBC.Item(i, 33)
                'SpellID(7) = DBC.Item(i, 34)
                'ItemCount(0) = DBC.Item(i, 35) ' Items To Trigger Spell?
                'ItemCount(1) = DBC.Item(i, 36)
                'ItemCount(2) = DBC.Item(i, 37)
                'ItemCount(3) = DBC.Item(i, 38)
                'ItemCount(4) = DBC.Item(i, 39)
                'ItemCount(5) = DBC.Item(i, 40)
                'ItemCount(6) = DBC.Item(i, 41)
                'ItemCount(7) = DBC.Item(i, 42)
                'Required_Skill_ID = DBC.Item(i, 43)
                'Required_Skill_Value = DBC.Item(i, 44)

                ItemSet.Add(id, New TItemSet(name, itemID, spellID, itemCount, requiredSkillID, requiredSkillValue))
            Next

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} ItemSets initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : ItemSet missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub LoadItemDisplayInfoDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\ItemDisplayInfo.dbc")

            Dim tmpItemDisplayInfo As TItemDisplayInfo

            For i As Integer = 0 To dbc.Rows - 1
                tmpItemDisplayInfo = New TItemDisplayInfo

                tmpItemDisplayInfo.ID = dbc.Item(i, 0)
                tmpItemDisplayInfo.RandomPropertyChance = dbc.Item(i, 11)
                tmpItemDisplayInfo.Unknown = dbc.Item(i, 22)

                ItemDisplayInfo.Add(tmpItemDisplayInfo.ID, tmpItemDisplayInfo)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} ItemDisplayInfos initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : ItemDisplayInfo missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub LoadItemRandomPropertiesDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\ItemRandomProperties.dbc")

            Dim tmpInfo As TItemRandomPropertiesInfo

            For i As Integer = 0 To dbc.Rows - 1
                tmpInfo = New TItemRandomPropertiesInfo

                tmpInfo.ID = dbc.Item(i, 0)
                tmpInfo.Enchant_ID(0) = dbc.Item(i, 2)
                tmpInfo.Enchant_ID(1) = dbc.Item(i, 3)
                tmpInfo.Enchant_ID(2) = dbc.Item(i, 4)

                ItemRandomPropertiesInfo.Add(tmpInfo.ID, tmpInfo)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} ItemRandomProperties initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : ItemRandomProperties missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

#End Region

#Region "Creatures"
    Public Sub LoadCreatureGossip()
        Try
            Dim gossipQuery As New DataTable
            WorldDatabase.Query("SELECT * FROM npc_gossip;", gossipQuery)

            Dim guid As ULong
            For Each gossip As DataRow In gossipQuery.Rows
                guid = gossip.Item("npc_guid")
                If CreatureGossip.ContainsKey(guid) = False Then
                    CreatureGossip.Add(guid, gossip.Item("textid"))
                End If
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} creature gossips initialized.", CreatureGossip.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : npc_gossip missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub

    Public Sub LoadCreatureFamilyDbc()
        Try
            Dim dbc As BufferedDBC = New BufferedDBC("dbc\CreatureFamily.dbc")

            Dim tmpInfo As CreatureFamilyInfo

            For i As Integer = 0 To dbc.Rows - 1
                tmpInfo = New CreatureFamilyInfo

                tmpInfo.ID = dbc.Item(i, 0)
                tmpInfo.Unknown1 = dbc.Item(i, 5)
                tmpInfo.Unknown2 = dbc.Item(i, 6)
                tmpInfo.PetFoodID = dbc.Item(i, 7)
                tmpInfo.Name = dbc.Item(i, 12, DBCValueType.DBC_STRING)

                CreaturesFamily.Add(tmpInfo.ID, tmpInfo)
            Next i

            Log.WriteLine(LogType.INFORMATION, "DBC: {0} CreatureFamilys initialized.", dbc.Rows - 1)
            dbc.Dispose()
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("DBC File : CreatureFamily missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub LoadCreatureMovements()
        Try
            Dim movementsQuery As New DataTable
            WorldDatabase.Query("SELECT * FROM waypoint_data ORDER BY id, point;", movementsQuery)

            Dim id As Integer
            For Each movement As DataRow In movementsQuery.Rows
                id = CType(movement.Item("id"), Integer)
                If CreatureMovement.ContainsKey(id) = False Then
                    CreatureMovement.Add(id, New Dictionary(Of Integer, CreatureMovePoint))
                End If
                CreatureMovement(id).Add(movement.Item("point"), New CreatureMovePoint(movement.Item("position_x"), movement.Item("position_y"), movement.Item("position_z"), movement.Item("delay"), movement.Item("move_flag"), movement.Item("action"), movement.Item("action_chance")))
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} creature movements for {1} creatures initialized.", movementsQuery.Rows.Count, CreatureMovement.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : Waypoint_Data missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub LoadCreatureEquipTable()
        Try
            Dim equipQuery As New DataTable
            WorldDatabase.Query("SELECT * FROM creature_equip_template_raw;", equipQuery)

            Dim entry As Integer
            For Each equipInfo As DataRow In equipQuery.Rows
                entry = CType(equipInfo.Item("entry"), Integer)
                If CreatureEquip.ContainsKey(entry) Then Continue For
                CreatureEquip.Add(entry, New CreatureEquipInfo(equipInfo.Item("equipmodel1"), equipInfo.Item("equipmodel2"), equipInfo.Item("equipmodel3"), equipInfo.Item("equipinfo1"), equipInfo.Item("equipinfo2"), equipInfo.Item("equipinfo3"), equipInfo.Item("equipslot1"), equipInfo.Item("equipslot2"), equipInfo.Item("equipslot3")))
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} creature equips initialized.", equipQuery.Rows.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : Creature_Equip_Template_raw missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
    Public Sub LoadCreatureModelInfo()
        Try
            Dim modelQuery As New DataTable
            WorldDatabase.Query("SELECT * FROM creature_model_info;", modelQuery)

            Dim entry As Integer
            For Each modelInfo As DataRow In modelQuery.Rows
                entry = CType(modelInfo.Item("modelid"), Integer)
                If CreatureModel.ContainsKey(entry) Then Continue For
                CreatureModel.Add(entry, New CreatureModelInfo(modelInfo.Item("bounding_radius"), modelInfo.Item("combat_reach"), modelInfo.Item("gender"), modelInfo.Item("modelid_other_gender")))
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} creature models initialized.", modelQuery.Rows.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : Creature_Model_Info missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

#Region "Quests"
    Public Sub LoadQuestStartersAndFinishers()
        Dim questStarters As New DataTable
        WorldDatabase.Query("SELECT * FROM creature_questrelation;", questStarters)

        For Each starter As DataRow In questStarters.Rows
            Dim entry As Integer = CInt(starter.Item("id"))
            Dim quest As Integer = CInt(starter.Item("quest"))
            If CreatureQuestStarters.ContainsKey(entry) = False Then CreatureQuestStarters.Add(entry, New List(Of Integer))
            CreatureQuestStarters(entry).Add(quest)
        Next

        Dim questStartersAmount As Integer = questStarters.Rows.Count
        questStarters.Clear()
        WorldDatabase.Query("SELECT * FROM gameobject_questrelation;", questStarters)
        For Each starter As DataRow In questStarters.Rows
            Dim entry As Integer = CInt(starter.Item("id"))
            Dim quest As Integer = CInt(starter.Item("quest"))
            If GameobjectQuestStarters.ContainsKey(entry) = False Then GameobjectQuestStarters.Add(entry, New List(Of Integer))
            GameobjectQuestStarters(entry).Add(quest)
        Next

        questStartersAmount += questStarters.Rows.Count
        Log.WriteLine(LogType.INFORMATION, "Database: {0} queststarters initated for {1} creatures and {2} gameobjects.", questStartersAmount, CreatureQuestStarters.Count, GameobjectQuestStarters.Count)
        questStarters.Clear()

        Dim questFinishers As New DataTable
        WorldDatabase.Query("SELECT * FROM creature_involvedrelation;", questFinishers)

        For Each starter As DataRow In questFinishers.Rows
            Dim entry As Integer = CInt(starter.Item("id"))
            Dim quest As Integer = CInt(starter.Item("quest"))
            If CreatureQuestFinishers.ContainsKey(entry) = False Then CreatureQuestFinishers.Add(entry, New List(Of Integer))
            CreatureQuestFinishers(entry).Add(quest)
        Next

        Dim questFinishersAmount As Integer = questFinishers.Rows.Count
        questFinishers.Clear()
        WorldDatabase.Query("SELECT * FROM gameobject_involvedrelation;", questFinishers)
        For Each starter As DataRow In questFinishers.Rows
            Dim entry As Integer = CInt(starter.Item("id"))
            Dim quest As Integer = CInt(starter.Item("quest"))
            If GameobjectQuestFinishers.ContainsKey(entry) = False Then GameobjectQuestFinishers.Add(entry, New List(Of Integer))
            GameobjectQuestFinishers(entry).Add(quest)
        Next

        questFinishersAmount += questFinishers.Rows.Count
        Log.WriteLine(LogType.INFORMATION, "Database: {0} questfinishers initated for {1} creatures and {2} gameobjects.", questFinishersAmount, CreatureQuestFinishers.Count, GameobjectQuestFinishers.Count)
        questFinishers.Clear()
    End Sub
#End Region

#Region "Loot"
    Public Sub LoadLootStores()
        LootTemplates_Creature = New LootStore("creature_loot_template")
        LootTemplates_Disenchant = New LootStore("disenchant_loot_template")
        LootTemplates_Fishing = New LootStore("fishing_loot_template")
        LootTemplates_Gameobject = New LootStore("gameobject_loot_template")
        LootTemplates_Item = New LootStore("item_loot_template")
        LootTemplates_Pickpocketing = New LootStore("pickpocketing_loot_template")
        LootTemplates_QuestMail = New LootStore("quest_mail_loot_template")
        LootTemplates_Reference = New LootStore("reference_loot_template")
        LootTemplates_Skinning = New LootStore("skinning_loot_template")
    End Sub
#End Region

#Region "Weather"
    Public Sub LoadWeather()
        Try
            Dim weatherQuery As New DataTable
            WorldDatabase.Query("SELECT * FROM game_weather;", weatherQuery)

            For Each weather As DataRow In weatherQuery.Rows
                Dim zone As Integer = weather.Item("zone")

                If WeatherZones.ContainsKey(zone) = False Then
                    Dim zoneChanges As New WeatherZone(zone)
                    zoneChanges.Seasons(0) = New WeatherSeasonChances(weather.Item("spring_rain_chance"), weather.Item("spring_snow_chance"), weather.Item("spring_storm_chance"))
                    zoneChanges.Seasons(1) = New WeatherSeasonChances(weather.Item("summer_rain_chance"), weather.Item("summer_snow_chance"), weather.Item("summer_storm_chance"))
                    zoneChanges.Seasons(2) = New WeatherSeasonChances(weather.Item("fall_rain_chance"), weather.Item("fall_snow_chance"), weather.Item("fall_storm_chance"))
                    zoneChanges.Seasons(3) = New WeatherSeasonChances(weather.Item("winter_rain_chance"), weather.Item("winter_snow_chance"), weather.Item("winter_storm_chance"))
                    WeatherZones.Add(zone, zoneChanges)
                End If
            Next

            Log.WriteLine(LogType.INFORMATION, "Database: {0} Weather zones initialized.", weatherQuery.Rows.Count)
        Catch e As DirectoryNotFoundException
            Console.ForegroundColor = ConsoleColor.DarkRed
            Console.WriteLine("Database : TransportQuery missing.")
            Console.ForegroundColor = ConsoleColor.Gray
        End Try
    End Sub
#End Region

End Module