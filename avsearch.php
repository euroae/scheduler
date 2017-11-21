<?php
include './../../MyWebSite/includes/availabilities.php';
include './../../MyWebSite/includes/staffmenu.php';
?>

<!DOCTYPE html>
<html>
    <head>
      <?php echo LoadStyles(); ?>
      <title>Availability Search</title>
		<script>
			//if the child wants to set the parent title, here it is
			parent.document.title = document.title;
			//or top.document.title = document.title;
    </script>
    </head>
    <body>
      <div class="flex_container">
      <?php
      echo loadMenu("avail");
      ?>
      <div class="flex-column">
		<form name='availability' method='post'>
			<table class='StandardTableNarrow'>
				<tr>
				  <th class="Top" colspan="7">Please choose the method of search: </th>
				</tr>
				<tr class='GreyRow'>
				  <th class='HeaderRow' width="80px">Option 1: </th>
				  <td colspan="6"><input class="FullWidthButton" type='submit' name='showAll' value="Display everyone's availabilities"></td>
				</tr>
				<tr class='GreyRow'>
				  <th class='HeaderRow'>Option 2: </th>
				  <td><?php echo UsernameDropDown(); ?></td>
				  <td colspan="5"><input class="FullWidthButton" type='submit' name='showSelected' value="Search availability of the selected user" ></td>
				</tr>
				<tr class="GreyRow">
				  <th class='HeaderRow'>Option 3: </th>
				  <td><select class="FullWidthButton" name="day"><?php echo LoadHoursDropDown(); ?></select></td>
				  <td colspan="1" nowrap>
						<?php echo "Start: "; echo LoadHoursBoxes("start"); ?>
						<?php echo " - "; echo "End: "; echo LoadHoursBoxes("end"); ?>
					</td>
				  <td colspan="4"><input class="FullWidthButton" type='submit' name='showForTime' value="Search the selected time interval"></td>
				</tr>
        <tr><td class='Bottom' colspan='7'>Generated at: <?php echo date("Y-m-d H:i:s"); ?></td></tr>
			</table>
		</form>
		<?php 
      if ($_SERVER["REQUEST_METHOD"] == "POST") {
        if ($_POST["showAll"]) {
          echo GetAllAvailability();
        }
        if ($_POST["showSelected"]) {
          echo GetAvailabilityFor($_POST["username"]);
        }
        if ($_POST["showForTime"]) {
          $start = CheckTimeInput($_POST["hourstart"], $_POST["minutestart"], $_POST["ampmstart"]);
          $end = CheckTimeInput($_POST["hourend"], $_POST["minuteend"], $_POST["ampmend"]);
          echo GetAvailableDuring($_POST["day"], $start, $end);
        }
      }
		?>
		
      </div>
    </div>
    </body>
</html>