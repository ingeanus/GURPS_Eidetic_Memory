using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eidetic_Memory
{
    public partial class Eidetic_Memory : Form
    {
        public Dictionary<String, Materials> flexible_mats = new Dictionary<String, Materials>()
        {
            { "Energy Cloth", new Materials(12, 0.014, 1, 500, 500, 240, 120, "—", "F", "F/O", "") },
            { "Monocrys", new Materials(11, 0.018, 3, 150, 75, 184, 92, "—", "F", "F/O", "The full DR only applies vs. piercing and cutting damage.") },
            { "Retro-Reflective Armour",  new Materials(11, 0.0025, 10000000, 1500, 1500, 1666, 166, "—", "F", "F/O", "The armor’s DR only applies vs. microwave and (in cinematic games) visible and near-infrared laser beams. It has 0 DR vs. other damage types.") },
            { "Bioplas", new Materials(10, 0.015, 3, 600, 300, 278, 92, "—", "B,F,T", "F/O", "The full DR only applies vs. piercing and burn damage.") },
            { "Nano-Ablative Polymer", new Materials(10, 0.012, 6, 150, 75, 275, 128, "—", "E,F", "F/O", "The full DR only applies against burning damage from lasers (including X-ray, gamma-ray, etc.).") },
            { "Advanced Nanoweave", new Materials(10, 0.024, 3, 150, 75, 138, 70, "—", "F", "F/O", "The full DR only applies vs. piercing and burn damage.") },
            { "Arachnoweave", new Materials(9, 0.03, 4, 600, 120, 96, 48, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Basic Nanoweave", new Materials(9, 0.03, 3, 750, 150, 110, 55, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.")},
            { "Laser-Ablative Polymer", new Materials(9, 0.018, 6, 150, 75, 128, 64, "—", "F,E", "F/O", "The full DR only applies against burning damage from lasers (including X-ray, gamma-ray, etc.).") },
            { "Magnetic Liquid Armour", new Materials(9, 0.032, 2, 200, 100, 90, 45, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Reflec", new Materials(9, 0.005, 10000000, 150, 150, 833, 83, "—", "F", "F/O", "The armor’s DR only applies vs. microwave and (in cinematic games) visible and near-infrared laser beams. It has 0 DR vs. other damage types.") },
            { "STF Liquid Armour", new Materials(9, 0.032, 1, 150, 75, 90, 45, "—", "F", "F/O", "") },
            { "Aramid Fabric", new Materials(8, 0.04, 4, 240, 240, 58, 24, "—", "B,F", "F/O", "The full DR only applies against piercing and cutting damage. The #3/52 article MULTIPLIED damage vs pi and cut, in contrast to all other materials which DIVIDE against others. This was standardized to the other materials! As well, TL 6+ Construction methods were added in Pyramid #3/85, but I added them to this! It's original is F/L not F/O!") },
            { "Ballistic Polymer", new Materials(8, 0.06, 2.5, 200, 50, 48, 24, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Ballistic Polymer",  new Materials(8, 0.04, 2.5, 250, 100, 75, 36, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Kevlar",  new Materials(8, .1, 4, 80, 20, 33, 16, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Kevlar",  new Materials(8, .08, 4, 120, 40, 40, 20, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Nomex",  new Materials(8, .055, 4, 35, 35, 10, 5, "—", "F", "F/O", "The full DR only applies against burning damage.") },
            { "Elastic Polymer",  new Materials(7, .16, 1, 100, 50, 16, 8, "—", "F", "F/O", "") },
            { "Nomex",  new Materials(7, .066, 4, 50, 25, 10, 5, "—", "F", "F/O", "The full DR only applies against burning damage.") },
            { "Nylon",  new Materials(7, .5, 1, 25, 6, 6, 3, "—", "F", "F/O", "")},
            { "Rubber",  new Materials(6, .45, 2, 5, 5, 14, 7, "—", "C,F,S", "F/O", "If assigned DR 2 or more, the full DR only applies against crushing damage.") },
            { "Cloth",  new Materials(0, .85, 1, 8, 8, 4, 4, "—", "C,F", "F", "The armor material is flexible if it has no more than 25% of its rated DR per inch. Flexible armor provides flexible DR, but can be donned in 2/3 the usual time.") },
            { "Leather",  new Materials(0, .9, 1, 10, 10, 8, 4, "—", "F", "F/L/SC", "The armor material is flexible if it has no more than 25% of its rated DR per inch. Flexible armor provides flexible DR, but can be donned in 2/3 the usual time.") },
            { "Silk",  new Materials(0, .85, 1, 100, 100, 4, 4, "—", "C,F", "F/L", "The armor material is flexible if it has no more than 25% of its rated DR per inch. Flexible armor provides flexible DR, but can be donned in 2/3 the usual time.") }
        };

        public Dictionary<String, Materials> rigid_mats = new Dictionary<String, Materials>()
        {
            {"Hyperdense",  new Materials(12, 0.04, 1, 50, 50, 2083, 417, "10", "L", "R/S", "") },
            {"Hyperdense Laminate", new Materials(12, 0.02, 1, 200, 200, 1040, 278, "35", "L", "R/S", "") },
            {"Diamondoid", new Materials(11, 0.06, 1, 50, 25, 232, 93, "—", "T", "R/S", "") },
            {"Diamondoid Laminate", new Materials(11, 0.03, 1, 200, 100, 420, 168, "35", "L", "R/S", "")},
            {"Advanced Nano-Laminate", new Materials(10, 0.04, 1, 200, 100, 166, 66, "35", "L", "R/S", "")},
            {"Advanced Polymer Nanocomposite", new Materials(10, 0.08, 1, 50, 25, 104, 42, "—", "T", "R/S", "")},
            {"Electromagnetic Armour", new Materials(10, 0.01, 1, 100, 50, 666, 264, "35", "M", "R/S", "") },
            {"Ceramic Nanocomposite", new Materials(9, 0.1, 1, 300, 75, 166, 66, "—", "S", "S", "")  },
            {"Polymer Nanocomposite", new Materials(9, 0.1, 1, 400, 100, 83, 33, "—", "—", "R/S", "") },
            {"Titanium Nanocomposite", new Materials(9, 0.12, 1, 250, 25, 174, 70, "—", "S", "R/S", "") },
            {"Improved Ceramic", new Materials(8, 0.15, 1, 100, 20, 111, 44, "—", "S", "S", "") },
            {"Laminated Polycarbonate", new Materials(8, 0.25, 1, 25, 12, 12, 5, "—", "S,T", "S", "") },
            {"Polymer Composite", new Materials(8, 0.22, 1, 40, 10, 28, 11, "—", "—", "R/S", "") },
            {"Titanium Composite", new Materials(8, 0.2, 1, 250, 25, 104, 42, "—", "—", "R/S", "") },
            {"Ultra-Strength Steel", new Materials(8, 0.35, 1, 30, 8, 116, 23, "—", "—", "R/S", "") },
            {"Steel, Very Hard", new Materials(7, 0.45, 1, 20, 20, 94, 18, "—", "—", "R/S", "") },
            {"Titanium", new Materials(7, 0.4, 1, 50, 50, 57, 12, "—", "—", "R/S", "") },
            {"Basic Ceramic", new Materials(7, 0.2, 1, 25, 12, 83, 35, "—", "S", "S", "") },
            {"Ballistic Resin", new Materials(7, 0.55, 1, 2.5, 1, 15, 6, "—", "—", "R/S", "") },
            {"Fiberglass", new Materials(7, 0.6, 1, 8, 4, 17, 7, "—", "S", "R/S", "") },
            {"High-Strength Aluminum", new Materials(7, 0.4, 1, 12, 6, 35, 10, "—", "—", "R/S", "") },
            {"Plastic", new Materials(7, 0.75, 1, 1.80, 1.80, 12, 3, "—", "T", "R/S", "") },
            {"Polycarbonate", new Materials(7, 0.45, 1, 10, 5, 10, 3, "—", "S", "R/S", "") },
            {"Titanium Alloy", new Materials(7, 0.35, 1, 50, 10, 66, 20, "—", "—", "R/S", "") },
            {"Aluminum", new Materials(6, 0.45, 1, 15, 1, 31, 5, "—", "—", "R/S", "") },
            {"Hard Steel", new Materials(6, 0.5, 1, 3.50, 3.50, 82, 16, "—", "—", "R/S", "") },
            {"High-Strength Steel", new Materials(6, 0.58, 1, 3, 3, 70, 16, "—", "—", "R/S", "") },
            {"Steel, hard", new Materials(4, 0.5, 1, 250, 5, 81, 16, "—", "—", "R/S", "") },
            {"Steel, strong", new Materials(3, 0.58, 1, 50, 5, 70, 14, "—", "—", "R/S", "") },
            {"Iron, cheap", new Materials(2, 0.8, 1, 15, 3, 52, 10, "—", "—", "R/S", "") },
            {"Iron, good", new Materials(2, 0.6, 1, 25, 5, 68, 14, "—", "—", "R/S", "") },
            {"Lead", new Materials(2, 2, 1, 12.5, 2.5, 30, 4, "—", "—", "P/SC/S", "") },
            {"Adamnt", new Materials(1, 0.33, 1, 900, 180, 27, 15, "—", "S", "SC/S", "") },
            {"Orichalcum", new Materials(1, 0.2, 1, 3000, 600, 204, 41, "—", "—", "R/S", "") },
            {"Bronze, cheap", new Materials(1, 0.9, 1, 60, 12, 48, 9, "—", "—", "R/S", "") },
            {"Bronze, good", new Materials(1, 0.6, 1, 100, 20, 68, 14, "—", "—", "R/S", "") },
            {"Copper", new Materials(1, 1.6, 1, 80, 80, 30, 5, "—", "—", "R/S", "") },
            {"Jade", new Materials(1, 1.2, 1, 62.5, 62.5, 13, 5, "—", "S", "SC/S", "") },
            {"Jade, gem-quality", new Materials(1, 1.2, 1, 125, 125, 13, 5, "—", "S", "SC/S", "") },
            {"Stone", new Materials(1, 1.2, 1, 12.5, 12.5, 13, 5, "—", "S", "SC/S", "") },
            {"Bone", new Materials(0, 1, 1, 12.5, 12.5, 8, 4, "—", "S", "SC/S", "") },
            {"Horn", new Materials(0, 1, 1, 12.5, 12.5, 8, 4, "—", "S", "SC/S", "") },
            {"Wood", new Materials(0, 1.4, 1, 3, 3, 1.5, 2, "—", "C,S", "SC/S", "") }
        };

        public Dictionary<String, Constructions> flexible_constr = new Dictionary<String, Constructions>()
        {
            {"Fabric", new Constructions(0, 1, 1, 1) },
            {"Layered Fabric", new Constructions(0, 1.2, 1.5, 2)  },
            {"Impact Absorbing Fabric", new Constructions(6, 0.65, 5, 2) },
            {"Optimized Fabric", new Constructions(6, 0.8, 2, 2) }
        };

        public Dictionary<String, Constructions> rigid_constr = new Dictionary<String, Constructions>()
        {
            {"Plate", new Constructions(1, 0.8, 5, 3) },
            {"Scale", new Constructions(1, 1.1, 0.8, 2) },
            {"Solid", new Constructions(1, 1, 1, 2) },
            {"Mail", new Constructions(2, 0.9, 1.2, 2) },
            {"Segmented Plate", new Constructions(2, 1.45, 1.5, 3) }
        };

        public Dictionary<String, List<String>> mat_constr_methods = new Dictionary<String, List<String>>()
        {
            {"Fabric", new List<string>(){"F", "F/O", "F/L", "F/L/SC"} },
            {"Layered Fabric", new List<string>(){"F/O", "F/L", "F/L/SC"} },
            {"Impact Absorbing Fabric", new List<string>(){"F", "F/O", "F/L/SC", } },
            {"Optimized Fabric", new List<string>(){"F/O"} },
            {"Plate", new List<string>(){"R/S", "P/SC/S"} },
            {"Scale", new List<string>(){"R/S", "SC/S", "F/L/SC", "P/SC/S"} },
            {"Solid", new List<string>(){"R/S", "SC/S" , "S", "P/SC/S"} },
            {"Mail", new List<string>(){"R/S"} },
            {"Segmented Plate", new List<string>(){"R/S", "P/SC/S"} }
        };

        public Eidetic_Memory()
        {
            InitializeComponent();
        }

        private double calculate_empty_weight()
        {
            double damage_dice = Decimal.ToDouble(damage_dice_data.Value);
            double superscience = 1;
            double energy_density = 3;
            double focal_weight = 1;
            double generator_weight = 1;

            if (superscience_weapon.Checked)
            {
                superscience = 0.5;
            }

            if (beam_type_data.SelectedIndex == 7) // Pulsar
            {
                energy_density = 6;
            }
            else if (beam_type_data.SelectedIndex == 1) // Force Beam
            {
                energy_density = 4;
            }
            else if (beam_type_data.SelectedIndex == 6) // Graviton
            {
                energy_density = 1.5;
            }

            double weight = Math.Pow((damage_dice * superscience / energy_density), 3) * focal_weight * generator_weight;

            return weight;
        }

        private void calculate_surface_area()
        {
            decimal sa_mult = num_samult.Value;
            double sa = 0;

            if (cb_skull.Checked) { sa += 1.4; }
            if (cb_face.Checked) { sa += 0.7; }
            if (cb_neck.Checked) { sa += 0.35; }
            if (cb_chest.Checked) { sa += 5.25; }
            else if (cb_vitals.Checked) { sa += 1; }
            if (cb_abdomen.Checked) { sa += 1.75; }
            else if (cb_groin.Checked) { sa += 0.35; }
            if (cb_rshoulder.Checked) { sa += 0.35; }
            if (cb_ruparm.Checked) { sa += 0.35; }
            if (cb_relbow.Checked) { sa += 0.175; }
            if (cb_rforearm.Checked) { sa += 0.875; }
            if (cb_lshoulder.Checked) { sa += 0.35; }
            if (cb_luparm.Checked) { sa += 0.35; }
            if (cb_lelbow.Checked) { sa += 0.175; }
            if (cb_lforearm.Checked) { sa += 0.875; }
            if (cb_rhand.Checked) { sa += 0.35; }
            if (cb_lhand.Checked) { sa += 0.35; }
            if (cb_rthigh.Checked) { sa += 1.575; }
            if (cb_rknee.Checked) { sa += 0.175; }
            if (cb_rshin.Checked) { sa += 1.75; }
            if (cb_lthigh.Checked) { sa += 1.575; }
            if (cb_lknee.Checked) { sa += 0.175; }
            if (cb_lshin.Checked) { sa += 1.75; }
            if (cb_rfoot.Checked) { sa += 0.35; }
            if (cb_lfoot.Checked) { sa += 0.35; }
            num_surfacearea.Value = Convert.ToDecimal(sa) * sa_mult;
        }

        private void damage_dice_data_ValueChanged(object sender, EventArgs e)
        {
            empty_weight_data.Value = Convert.ToDecimal(calculate_empty_weight());
        }

        private void beam_type_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            empty_weight_data.Value = Convert.ToDecimal(calculate_empty_weight());
        }

        private void focal_array_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            empty_weight_data.Value = Convert.ToDecimal(calculate_empty_weight());
        }

        private void generator_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            empty_weight_data.Value = Convert.ToDecimal(calculate_empty_weight());
        }

        private void Blasters_and_Laser_Design_Click(object sender, EventArgs e)
        {

        }

        private void cb_rarm_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_rarm.Checked;
            cb_rshoulder.Checked = check;
            cb_ruparm.Checked = check;
            cb_relbow.Checked = check;
            cb_rforearm.Checked = check;

            calculate_surface_area();
        }

        private void cb_larm_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_larm.Checked;
            cb_lshoulder.Checked = check;
            cb_luparm.Checked = check;
            cb_lelbow.Checked = check;
            cb_lforearm.Checked = check;

            calculate_surface_area();
        }

        private void cb_torso_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_torso.Checked;
            cb_chest.Checked = check;
            cb_abdomen.Checked = check;

            calculate_surface_area();
        }

        private void cb_chest_CheckedChanged(object sender, EventArgs e)
        {
            cb_vitals.Checked = cb_chest.Checked;

            calculate_surface_area();
        }

        private void cb_abdomen_CheckedChanged(object sender, EventArgs e)
        {
            cb_groin.Checked = cb_abdomen.Checked;

            calculate_surface_area();
        }

        private void cb_head_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_head.Checked;
            cb_skull.Checked = check;
            cb_face.Checked = check;

            calculate_surface_area();
        }

        private void cb_rleg_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_rleg.Checked;
            cb_rthigh.Checked = check;
            cb_rknee.Checked = check;
            cb_rshin.Checked = check;

            calculate_surface_area();
        }

        private void cb_lleg_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_lleg.Checked;
            cb_lthigh.Checked = check;
            cb_lknee.Checked = check;
            cb_lshin.Checked = check;

            calculate_surface_area();
        }
        
        private void cb_rhand_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lhand_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lfoot_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rfoot_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_vitals_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_groin_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void num_weight_Leave(object sender, EventArgs e)
        {
            double scale = Math.Pow(Decimal.ToDouble(num_weight.Value/150), (2.0/3.0));
            num_samult.Value = Convert.ToDecimal(scale);
        }

        private void num_samult_Leave(object sender, EventArgs e)
        {
            double scale = 150 * Math.Pow(Decimal.ToDouble(num_samult.Value), (3.0/2.0));
            num_weight.Value = Convert.ToDecimal(scale);
            calculate_surface_area();
        }

        private void num_armourTL_ValueChanged(object sender, EventArgs e)
        {
            get_Armour_Materials();
            get_Armour_Construction();
            get_Concealability();
        }

        private void cb_rigid_CheckedChanged(object sender, EventArgs e)
        {
            get_Armour_Materials();
            get_Armour_Construction();
        }

        private void box_constr_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Construction_Stats();
            get_ArmourDR();
            get_Construction_Warnings();
            get_Cost();
        }

        private void box_armourmat_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Material_Stats();
            get_Armour_Construction();
            get_Concealability();
            get_ArmourDR();
            get_Cost();
            get_Construction_Warnings();
        }

        private void num_DR_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourDR();
            get_Concealability();
        }

        private void num_armourweight_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourWeight();
            get_Concealability();
            get_Cost();
        }

        private void num_cost_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cb_neck_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_skull_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_face_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rshoulder_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_ruparm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_relbow_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rforearm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lshoulder_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_luparm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lelbow_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lforearm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rthigh_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rknee_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rshin_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lthigh_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lknee_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lshin_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void num_surfacearea_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourDR();
        }

        private void cb_multtomax_CheckedChanged(object sender, EventArgs e)
        {
            get_Material_Stats();
        }

        private void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_full.Checked;
            cb_head.Checked = check;
            cb_neck.Checked = check;
            cb_torso.Checked = check;
            cb_rarm.Checked = check;
            cb_larm.Checked = check;
            cb_rhand.Checked = check;
            cb_lhand.Checked = check;
            cb_rleg.Checked = check;
            cb_lleg.Checked = check;
            cb_rfoot.Checked = check;
            cb_lfoot.Checked = check;

            calculate_surface_area();
        }

        private void get_Armour_Materials()
        {
            decimal TL = num_armourTL.Value;

            box_armourmat.Items.Clear();

            if (cb_rigid.Checked)
            {
                foreach (var material in rigid_mats)
                {
                    if (TL >= material.Value.TL)
                    {
                        box_armourmat.Items.Add(material.Key);
                    }
                }
            }
            else
            {
                foreach (var material in flexible_mats)
                {
                    if (TL >= material.Value.TL)
                    {
                        box_armourmat.Items.Add(material.Key);
                    }
                }
            }
        }

        private void get_Armour_Construction()
        {
            decimal TL = num_armourTL.Value;
            Materials mat;

            box_constr.Items.Clear();

            if (cb_rigid.Checked)
            {
                try
                {
                    mat = rigid_mats[box_armourmat.Text];

                    foreach (var constr in rigid_constr)
                    {
                        if (TL >= constr.Value.TL && mat_constr_methods.ContainsKey(constr.Key) && mat_constr_methods[constr.Key].Contains(mat.construction))
                        {
                            box_constr.Items.Add(constr.Key);
                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            else
            {
                try
                {
                    mat = flexible_mats[box_armourmat.Text];

                    foreach (var constr in flexible_constr)
                    {
                        if (TL >= constr.Value.TL && mat_constr_methods.ContainsKey(constr.Key) && mat_constr_methods[constr.Key].Contains(mat.construction))
                        {
                            box_constr.Items.Add(constr.Key);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        private void get_Material_Stats()
        {
            String cur_mat = box_armourmat.Text;
            decimal cur_TL = num_armourTL.Value;
            Materials mat;

            if (cb_rigid.Checked)
            {
                mat = rigid_mats[cur_mat];
            }
            else
            {
                mat = flexible_mats[cur_mat]; // Access from clicking checkbox 
            }

            lab_nummatTL.Text = mat.TL.ToString();
            lab_numWM.Text = mat.WM.ToString();
            if (cur_TL > mat.TL && cur_TL >= 5) // Checks to see if it is a high enough TL to lower cost. As well, in Low Tech this only happens at TL 5+ (and again at 6+ for steel which is accounted below).
            {
                if (cur_TL >= 6 && (cur_mat == "Steel, strong" || cur_mat == "Steel, hard"))
                {
                    lab_numCM.Text = (mat.highTLCM / 5).ToString(); // Divides by 5 again for TL 6+ getting the 1/25 cost.
                }
                else
                {
                    lab_numCM.Text = mat.highTLCM.ToString();
                }
            }
            else
            {
                lab_numCM.Text = mat.CM.ToString();
            }
            lab_numdrin.Text = mat.DRin.ToString();
            if (cb_multtomax.Checked)
            {
                lab_nummaxdr.Text = Math.Ceiling((mat.maxDR * num_samult.Value)).ToString();
            }
            else
            {
                lab_nummaxdr.Text = mat.maxDR.ToString();
            }
            lab_nummindr.Text = mat.minDR;
            lab_numnotes.Text = mat.notes;
            lab_numconstroptions.Text = mat.construction;
        }

        private void get_Construction_Stats()
        {
            string cur_constr = box_constr.Text;
            Constructions constr;

            try
            {
                if (cb_rigid.Checked)
                {
                    constr = rigid_constr[cur_constr];
                }
                else
                {
                    constr = flexible_constr[cur_constr];
                }

                lab_numCW.Text = constr.CW.ToString();
                lab_numCC.Text = constr.CC.ToString();
                lab_numconstrminDR.Text = constr.minDR.ToString();
            }
            catch (Exception e)
            {

            }
        }

        private void get_Concealability()
        {
            decimal dr = num_DR.Value;
            decimal maxdr = Decimal.Parse(lab_nummaxdr.Text);
            if (!cb_rigid.Checked)
            {
                if (dr > maxdr / 2)
                {
                    lab_numconceal.Text = "Not Concealable :: Heavy Clothing.";
                }
                else if (dr > maxdr / 4)
                {
                    lab_numconceal.Text = "Concealable :: Normal or Under Clothing.";
                }
                else if (dr > maxdr / 6)
                {
                    lab_numconceal.Text = "Very Concealable :: Light Clothing.";
                }
                else if (dr > 0)
                {
                    lab_numconceal.Text = "Extremely Concealable :: Very Light Clothing.";
                }
                else
                {
                    lab_numconceal.Text = "";
                }
            }
            else
            {
                lab_numconceal.Text = "Not Concealable :: Rigid Armour.";
            }
        }

        private void get_ArmourDR()
        {
            decimal sa = num_surfacearea.Value;
            decimal wm = Decimal.Parse(lab_numWM.Text);
            decimal cw = Decimal.Parse(lab_numCW.Text);
            decimal dr = num_DR.Value;

            num_armourweight.Value = sa * wm * cw * dr;
        }

        private void get_ArmourWeight()
        {

            decimal weight = num_armourweight.Value;
            decimal sa = num_surfacearea.Value;
            decimal wm = Decimal.Parse(lab_numWM.Text);
            decimal cw = Decimal.Parse(lab_numCW.Text);

            if (sa * wm * cw == 0)
            {
                num_DR.Value = 0;
            }
            else
            {
                num_DR.Value = weight / (sa * wm * cw);
            }
        }

        private void get_Cost()
        {
            decimal weight = num_armourweight.Value;
            decimal cm = Decimal.Parse(lab_numCM.Text);
            decimal cc = Decimal.Parse(lab_numCC.Text);

            num_cost.Value = weight * cm * cc;
        }

        private void get_Construction_Warnings()
        {
            String constr = box_constr.Text;
            String mat = box_armourmat.Text;
            if ((constr == "Solid" || constr == "Plate") && (mat == "Iron, cheap" || mat == "Iron, good" || mat == "Steel, strong"))
            {
                lab_constrwarn.Text = "Construction requires TL 4 for any body part except head!";
            }
            else if (constr == "Layered Fabric" && mat == "Leather")
            {
                lab_constrwarn.Text = "Construction requires TL 1 for Layered Leather!";
            }
            else
            {
                lab_constrwarn.Text = "";
            }
        }

        private String return_locations()
        {
            String location_string = "";
            List<String> locations = new List<string>();

            if (cb_head.Checked) locations.Add("Head");
            else
            {
                if (cb_skull.Checked) locations.Add("Skull");
                else if (cb_face.Checked) locations.Add("Face");
            }
            if (cb_neck.Checked) locations.Add("Neck");
            if (cb_torso.Checked) locations.Add("Torso");
            else
            {
                if (cb_chest.Checked) locations.Add("Chest");
                if (cb_vitals.Checked) locations.Add("Vitals"); // While chest DOES imply Vitals are covered, often I've seen these noted independantly, so I will do so as well.
                if (cb_abdomen.Checked) locations.Add("Abdomen");
                else if (cb_groin.Checked) locations.Add("Groin");
            }
            if (cb_rarm.Checked) locations.Add("Right Arm");
            else
            {
                if (cb_rshoulder.Checked) locations.Add("Right Shoulder");
                if (cb_ruparm.Checked) locations.Add("Right Upper Arm");
                if (cb_relbow.Checked) locations.Add("Right Elbow");
                if (cb_rforearm.Checked) locations.Add("Right Forearm");
            }
            if (cb_larm.Checked) 
            { 
                locations.Add(locations.Contains("Right Arm") ? "Arms" : "Left Arm");
                locations.Remove(locations.Contains("Right Arm") ? "Right Arm" : "");
            }
            else
            {
                if (cb_lshoulder.Checked)
                {
                    locations.Add(locations.Contains("Right Shoulder") ? "Shoulders" : "Left Shoulder");
                    locations.Remove(locations.Contains("Right Shoulder") ? "Right Shoulder" : "");
                }
                if (cb_luparm.Checked)
                {
                    locations.Add(locations.Contains("Right Upper Arm") ? "Upper Arms" : "Left Upper Arm");
                    locations.Remove(locations.Contains("Right Upper Arm") ? "Right Upper Arm" : "");
                }
                if (cb_lelbow.Checked)
                {
                    locations.Add(locations.Contains("Right Elbow") ? "Elbows" : "Left Eblow");
                    locations.Remove(locations.Contains("Right Elbow") ? "Right Elbow" : "");
                }
                if (cb_lforearm.Checked)
                {
                    locations.Add(locations.Contains("Right Forearm") ? "Forearms" : "Left Forearm");
                    locations.Remove(locations.Contains("Right Forearm") ? "Right Forearm" : "");
                }
            }
            if (cb_rhand.Checked) locations.Add("Right Hand");
            if (cb_lhand.Checked)
            {
                locations.Add(locations.Contains("Right Hand") ? "Hands" : "Left Hand");
                locations.Remove(locations.Contains("Right Hand") ? "Right Hand" : "");
            }
            if (cb_rleg.Checked) locations.Add("Right Leg");
            else
            {
                if (cb_rthigh.Checked) locations.Add("Right Thigh");
                if (cb_rknee.Checked) locations.Add("Right Knee");
                if (cb_rshin.Checked) locations.Add("Right Shin");
            }
            if (cb_lleg.Checked)
            {
                locations.Add(locations.Contains("Right Leg") ? "Legs" : "Left Leg");
                locations.Remove(locations.Contains("Right Leg") ? "Right Leg" : "");
            }
            else
            {
                if (cb_lthigh.Checked)
                {
                    locations.Add(locations.Contains("Right Thigh") ? "Thighs" : "Left Thigh");
                    locations.Remove(locations.Contains("Right Thigh") ? "Right Thigh" : "");
                }
                if (cb_lknee.Checked) 
                { 
                    locations.Add(locations.Contains("Right Knee") ? "Knees" : "Left Knee");
                    locations.Remove(locations.Contains("Right Knee") ? "Right Knee" : "");
                }
                if (cb_lshin.Checked)
                {
                    locations.Add(locations.Contains("Right Shin") ? "Shins" : "Left Shin");
                    locations.Remove(locations.Contains("Right Shin") ? "Right Shin" : "");
                }
            }
            if (cb_rfoot.Checked) locations.Add("Right Foot");
            if (cb_lfoot.Checked)
            {
                locations.Add(locations.Contains("Right Foot") ? "Feet" : "Left Foot");
                locations.Remove(locations.Contains("Right Foot") ? "Right Foot" : "");
            }

            foreach (String s in locations)
            {
                location_string += s + ", ";
            }

            location_string = location_string.Substring(0, location_string.Length - 2);

            return location_string;
        }

        private void btn_save1_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr1.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr1.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight1.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost1.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal1.Text = lab_numconceal.Text;
            lab_numsavenotes1.Text = lab_numnotes.Text;
            lab_numsaveloc1.Text = return_locations();
        }

        private void btn_save2_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr2.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr2.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight2.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost2.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal2.Text = lab_numconceal.Text;
            lab_numsavenotes2.Text = lab_numnotes.Text;
            lab_numsaveloc2.Text = return_locations();
        }

        private void btn_save3_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr3.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr3.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight3.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost3.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal3.Text = lab_numconceal.Text;
            lab_numsavenotes3.Text = lab_numnotes.Text;
            lab_numsaveloc3.Text = return_locations();
        }

        private void btn_save4_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr4.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr4.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight4.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost4.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal4.Text = lab_numconceal.Text;
            lab_numsavenotes4.Text = lab_numnotes.Text;
            lab_numsaveloc4.Text = return_locations();
        }
    }

    public class Materials
    {
        public int TL;
        public double WM;
        public double drdivisor;
        public double CM;
        public double highTLCM;
        public double DRin;
        public int maxDR;
        public String minDR;
        public String notes;
        public String construction;
        public String footnotes;

        public Materials(int tech, double weight, double div, double cost, double high, double dr, int max, String min, String n, String constr, String fn)
        {
            TL = tech;
            WM = weight;
            drdivisor = div;
            CM = cost;
            highTLCM = high;
            DRin = dr;
            maxDR = max;
            minDR = min;
            notes = n;
            construction = constr;
            footnotes = fn;
        }
    }

    public class Constructions
    {
        public int TL;
        public double CW;
        public double CC;
        public int minDR;

        public Constructions(int t, double w, double c, int dr)
        {
            TL = t;
            CW = w;
            CC = c;
            minDR = dr;
        }
    }
}
